using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Senaka.lib
{
    class GFG : IComparer<int[]>
    {
        // order and then category
        public int Compare(int[] x, int[] y)
        {
            int comp = x[1].CompareTo(y[1]);
            if (comp == 0) comp = x[2].CompareTo(y[2]);
            return comp;
        }
    }

    static class Rack
    {
        public enum SIZE
        {
            SMALL = 1, MEDIUM = 2, LARGE = 4
        }
        public enum OT
        {
            THICK8 = 8, THICK16 = 16
        }
        public enum TYPE
        {
            SLIDER = 32, CASE = 64, SU = 128, SHAPE = 256
        }

        private static float MEDIUM_SIZE = 34;
        private static float LARGE_SIZE = 44;

        private static List<string[]> glasses; // unsorted data (original data)
        public static List<string[]> optimized; // sorted glasses
        public static List<string> rack; // rack id list

        private static int[] letter; // small, medium, large, SU, SHAPE  --- order of alphabet 0: A, 1: B, 2: C, ...
        private static List<List<int[]>> data; // glass index, order id, category, qty (Order Groups)
        private static List<List<int>> rack_box; // category (first element - index 0), glasses id list....
        public static List<int[]> su_history;
        public static List<string[]> su_shipping;

        public static void initRack()
        {
            glasses = new List<string[]>();
            optimized = new List<string[]>();
            rack = new List<string>();
            letter = new int[5] { 0, 0, 0, 0, 0 };
            data = new List<List<int[]>>();
            rack_box = new List<List<int>>();
            su_shipping = new List<string[]>();
            for (int i = 0; i < Settings.SU_Shipping.Count; i++)
            {
                su_shipping.Add(Settings.SU_Shipping[i]);
            }
            
            for (int i = 0; i < Settings.SU_History.Count; i++)
            {
                rack_box.Add(new List<int>() { int.Parse(Settings.SU_History[i][2]) });
                for (int j = 0; j < int.Parse(Settings.SU_History[i][1]); j++)
                {
                    rack_box[i].Add(-1);
                }
            }
        }

        public static List<int[]> listToList(List<string[]> list)
        {
            return list.ConvertAll(arrayToArray);
        }

        public static List<string[]> listToList(List<int[]> list)
        {
            return list.ConvertAll(arrayToArray);
        }

        public static int[] arrayToArray(string[] array)
        {
            return Array.ConvertAll(array, int.Parse);
        }

        public static string[] arrayToArray(int[] array)
        {
            return Array.ConvertAll(array, x => x.ToString());
        }

        public static void addGlass(int index, string[] glass)
        {
            glasses.Add(glass);
            int order = int.Parse(glass[(int)GLASS.ORDER]), qty = int.Parse(glass[(int)GLASS.QTY]);
            int i, j, RACK_SIZE, category = getType(glass);
            if (category != (int)TYPE.SHAPE)
            {
                if (category == (int)TYPE.SU) category += getThick(glass);
                else category += getSize(glass) + getThick(glass);
            }

            if (category == (int)TYPE.SHAPE) RACK_SIZE = 40;
            else if ((category & (int)OT.THICK16) > 0) RACK_SIZE = Settings.Rack_Size_16;
            else RACK_SIZE = Settings.Rack_Size_8;

            for (i = 0; i < data.Count; i++)
            {
                if (data[i][0][1] == order && data[i][0][2] == category && data[i].Count + qty <= RACK_SIZE) break;
            }

            if (i == data.Count) data.Add(new List<int[]>());

            for (j = 0; j < qty; j++)
            {
                data[i].Add(new int[] { index, order, category, qty });
            }
        }

        private static int getSize(string[] glass)
        {
            int size_type;
            float width = float.Parse(glass[(int)GLASS.WIDTH]);
            float height = float.Parse(glass[(int)GLASS.HEIGHT]);
            if (width < MEDIUM_SIZE || height < MEDIUM_SIZE)
            {
                size_type = (int)SIZE.SMALL;
            }
            else if ((MEDIUM_SIZE <= width && width <= LARGE_SIZE) || (MEDIUM_SIZE <= height && height <= LARGE_SIZE))
            {
                size_type = (int)SIZE.MEDIUM;
            }
            else
            {
                size_type = (int)SIZE.LARGE;
            }
            return size_type;
        }

        public static int getThick(string[] glass)
        {
            string thick = glass[(int)GLASS.OT];
            //1/2,  9/19,  5/8, 11/16, 3/4, 13/16, 7/8,
            if (thick.Contains("1/2") || thick.Contains("9/19") || thick.Contains("5/8") || thick.Contains("11/16") || thick.Contains("3/4") || thick.Contains("13/16") || thick.Contains("7/8"))
                return (int)OT.THICK16;
            else //15/16, 1, 1 1/16,  1 1/8, 1 3/16, 1 1/4, 1 5/16, 1 3/8, 1 7/16, 1 1/2
                return (int)OT.THICK8;
        }

        public static int getType(string[] glass)
        {
            int type = 0;
            string wType = glass[(int)GLASS.WINDOW_TYPE].Remove(0, 12);
            for (int i = 0; i < Settings.Window_Type.Count; i++)
            {
                if (Settings.Window_Type[i].Contains(wType.ToUpper()))
                {
                    type = Convert.ToInt16(Math.Pow(2, i + 5));
                    break;
                }
            }
            return type;
        }

        public static void optimize()
        {
            int category, i, j, k, RACK_SIZE;
            for (i = 0; i < data.Count; i++)
            {
                category = data[i][0][2];
                if ((category & (int)TYPE.SU) > 0)
                {
                    for (j = 0; j < data[i].Count; ) // j =+ data[i][j][3]
                    {
                        bool added = false;
                        int qty;
                        for (k = 0; k < su_shipping.Count; k++)
                        {
                            qty = int.Parse(su_shipping[k][3]);
                            if (category == int.Parse(su_shipping[k][2]) && data[i][j][3] <= qty)
                            {
                                if (data[i][j][3] == int.Parse(su_shipping[k][3]))
                                {
                                    rack.Add(su_shipping[k][1]);
                                    optimized.Add(glasses[data[i][j][0]]);
                                    su_shipping.Remove(su_shipping[k]);
                                    qty = data[i][j][3];
                                    for (k = 0; k < qty; k++) data[i].Remove(data[i][j]);
                                    added = true;
                                    break;
                                }
                                else if (data[i][j][3] < qty)
                                {
                                    rack.Add(su_shipping[k][1]);
                                    optimized.Add(glasses[data[i][j][0]]);
                                    qty -= data[i][j][3];
                                    su_shipping[k][3] = qty.ToString();
                                    string[] rackId = su_shipping[k][1].Split('-');
                                    if (rackId.Length == 3)
                                    {
                                        rackId[2] = (int.Parse(rackId[2]) + data[i][j][3]).ToString();
                                        su_shipping[k][1] = rackId[0] + "-" + rackId[1] + "-" + rackId[2];
                                    }
                                    qty = data[i][j][3];
                                    for (k = 0; k < qty; k++) data[i].Remove(data[i][j]);
                                    added = true;
                                    break;
                                }
                            }
                        }
                        if (!added) j += data[i][j][3];
                    }
                }

                if (category == (int)TYPE.SHAPE) RACK_SIZE = 40;
                else if ((category & (int)OT.THICK16) > 0) RACK_SIZE = Settings.Rack_Size_16;
                else RACK_SIZE = Settings.Rack_Size_8;

                for (j = 0; j < rack_box.Count; j++)
                {
                    if (rack_box[j][0] == category && rack_box[j].Count - 1 + data[i].Count <= RACK_SIZE) break;
                }
                if (j == rack_box.Count) rack_box.Add(new List<int>() { category });
                for (k = 0; k < data[i].Count; k++)
                {
                    rack_box[j].Add(data[i][k][0]);
                }
            }

            int id, su = 0, type;
            string prefix;
            int[] last_su_rack_info = new int[] { 0, 0 };
            su_history = new List<int[]>();
            for (i = 0; i < rack_box.Count; i++)
            {
                id = -1;
                prefix = ""; type = 0; // SMALL RACK
                category = rack_box[i][0];
                if (category == (int)TYPE.SHAPE)
                {
                    prefix = "SHAPE-";
                    type = 4;
                }
                else if ((category & (int)TYPE.SU) > 0)
                {
                    prefix = "SU-";
                    type = 3;
                    if (su < Settings.SU_History.Count)
                    {
                        letter[type] = int.Parse(Settings.SU_History[su][0]);
                    }
                }
                else if ((category & (int)SIZE.LARGE) > 0)
                {
                    prefix = "BG-";
                    type = 2;
                }
                else if ((category & (int)SIZE.MEDIUM) > 0)
                {
                    prefix = "MD-";
                    type = 1;
                }
                for (j = 1; j < rack_box[i].Count; j++)
                {
                    if (id != rack_box[i][j])
                    {
                        id = rack_box[i][j];
                        rack.Add(prefix + getRackID(letter[type], j));
                        optimized.Add(glasses[id]);
                    }
                }
                if ((category & (int)TYPE.SU) > 0) // type == 3
                {
                    if ((category & (int)OT.THICK16) > 0) RACK_SIZE = Settings.Rack_Size_16;
                    else RACK_SIZE = Settings.Rack_Size_8;

                    if (j < RACK_SIZE)
                    {
                        su_history.Add(new int[] { letter[type], j - 1, category });
                    }
                    else
                    {
                        last_su_rack_info = new int[] { letter[type], j - 1, category };
                    }
                    su++;
                }
                letter[type]++;
            }
            if (su_history.Count > 0 && su_history[su_history.Count - 1][0] < last_su_rack_info[0])
            {
                su_history.Add(last_su_rack_info);
            }
        }

        private static string getRackID(int i, int j)
        {
            int m;
            string letter = "";
            do
            {
                m = i % 26;
                letter = letter + new string((char)(m + 65), 1);
                i = i / 26;
            } while (i > 26);
            return letter + "-" + j.ToString();
        }

        public static string getRackCount(int category = 0)
        {
            int count = 0;
            foreach (List<int> rack in rack_box)
            {
                if ((rack[0] & category) == category) count++;
            }
            return count.ToString();
        }

        public static string getRackUnit(int category = 0)
        {
            int count = 0;
            foreach (List<int> rack in rack_box)
            {
                if ((rack[0] & category) == category) count += rack.Count - 1;
            }
            return count.ToString();
        }
    }
}
