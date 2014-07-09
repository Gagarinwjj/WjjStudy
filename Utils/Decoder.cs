using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Utils
{
    public class Decoder
    {

        #region 源对应字符串 
        private string std_str = "1234567890ABCDEFGHIJKLMNOPQRSTUVWXYZ!@$^*()_+-/|':{}[]";
        #endregion

        #region 密码查表字符串
        private string[] en_str = new string[10]
        {
        "{}[]16Z!@$7CDY^*ESJKTU)_+-V(W8F2GHIL345MNOPQR90ABX/|:",
        "$7GHIL3{QR9BX/|}[16Z!@CDTU(Y^*ESJ:K)_+-VW8F2]45MNOP0A",
        "FGP0A2]45M$7HIL3{QR916^*ESJ:K)_+-VWBX/|}[8NOZ!@CDTU(Y",
        "8F2]HI45MN0$7DT/|}[16Z!XCU(Y^@L3{QR9B*EGASJ:K)_+-VWOP",
        "XCWU(Y^6Z!EGA5MS8F2]HIB*OP4N0$7DT/|}[1J:K)_+-V@L3{QR9",
        "0$7DT/|}[1XCW8QR9U(Y^F2]HIB*OP45MNJ:K)_+-V@L3{6Z!EGAS",
        "NJ:K)_+-V@L30$8QR]HIB*O9U(Y^F245M{6Z!EGAPS7DT/|}[1XCW",
        "^F24NR]HIB*OJ:K)_+-V@L30$8Q9U(S7D1XCWT/|}[Y5M{6Z!EGAP",
        "CWT/|}[Y5M{6Z24N$8Q9U(S7D1XA!EG^FPR]HIB*OJ:K)_+-V@L30",
        "T309U(S7|}[Y5M8QG^FPR]HIB*OJ:K)_2/LCW{6Z4N$+-V@D1XA!E",
        };
        #endregion

        #region
        private string st_str = "acdhjklmnopqrstuvwxy";
        #endregion

        #region
        private string in_str = "befgiz";
        #endregion

        #region
        private string dc_sort = "LXQPAZDBCH";
        #endregion

        #region EnCode() 字符串加密
        public string EnCode(string scode)
        {
            string ecode = "", tmpstr = "";
            Random rnd = new Random();
            int hcnt = 0, encnt = 0, cnt = 0, incnt = 0, zcnt = 0;

            hcnt = rnd.Next(1, 4);

            for (cnt = 0; cnt < hcnt; cnt++)
            {
                encnt = rnd.Next(0, 20);
                ecode += st_str.Substring(encnt, 1);
            }

            encnt = rnd.Next(0, 10);
            ecode += dc_sort.Substring(encnt, 1);

            cnt = 0;
            foreach (char cdata in scode)
            {
                zcnt = cnt % 54;
                cnt++;


                if (cnt % 7 == 0)
                {
                    hcnt = rnd.Next(0, 6);
                    ecode += in_str.Substring(hcnt, 1);
                    if (rnd.Next(0, 10) > 4)
                    {
                        hcnt = rnd.Next(0, 6);
                        ecode += in_str.Substring(hcnt, 1);
                    }
                }

                tmpstr = string.Format("{0:X2}", (int)cdata);

                if (tmpstr.Length < 4)
                {
                    hcnt = rnd.Next(0, 20);
                    ecode += st_str.Substring(hcnt, 1);
                    hcnt = rnd.Next(0, 20);
                    ecode += st_str.Substring(hcnt, 1);
                }

                foreach (char mchar in tmpstr)
                {
                    incnt = std_str.IndexOf(mchar);
                    incnt = (incnt + zcnt) % 54;
                    ecode += en_str[encnt].Substring(incnt, 1);
                }
            }
            return ecode;
        }
        #endregion

        #region DeCode() 字符串解密
        public string DeCode(string ecode)
        {
            string scode = "", tmpstr = "", workstr = "", codestr = "";
            int hcnt = 0, cnt = 0, encnt = 0, xcnt = 0, ycnt = 0, zcnt = 0;

            if (ecode.Length > 3)
            {
                tmpstr = ecode.Substring(0, 4);
                foreach (char mchar in tmpstr)
                {
                    cnt++;
                    if (st_str.IndexOf(mchar) < 0 && hcnt == 0)
                    {
                        hcnt = cnt;
                        encnt = dc_sort.IndexOf(mchar);
                    }
                }

                if (hcnt != 0 && encnt > -1 && encnt < 10)
                {
                    tmpstr = ecode.Substring(hcnt);
                    foreach (char mchar in in_str)
                    {
                        tmpstr = tmpstr.Replace(mchar.ToString(), "");
                    }

                    hcnt = Convert.ToInt32(tmpstr.Length / 4) * 4;
                    ycnt = 0;

                    for (cnt = 0; cnt < hcnt; cnt += 4)
                    {
                        zcnt = ycnt % 54;
                        codestr = "";
                        workstr = tmpstr.Substring(cnt, 4);

                        foreach (char mchar in workstr)
                        {
                            if (st_str.IndexOf(mchar) < 0)
                            {
                                xcnt = en_str[encnt].IndexOf(mchar);
                                if (xcnt > -1)
                                {
                                    if (cnt >= zcnt)
                                        xcnt = xcnt - zcnt;
                                    else
                                        xcnt = 54 + xcnt - zcnt;
                                    codestr += std_str.Substring(xcnt, 1);
                                }
                            }
                        }
                        try
                        {
                            scode += Convert.ToChar(Convert.ToInt32("0x" + codestr, 16));
                        }
                        catch
                        {
                            scode = "";
                            cnt = hcnt;
                        }
                        ycnt++;
                    }
                }
            }
            return scode;
        }
        #endregion

    }
}
