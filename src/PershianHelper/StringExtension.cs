namespace PershianHelper;
using System;
using System.Collections.Generic;

public static class StringExtension
{

    public static string ConvertLongToText(this long Number)
    {
        //---------------------------------------------------'
        List<long> Num = new List<long>();
        List<string> Word = new List<string>();
        string Text = "";
        //---------------------------------------------------'
        Number = Math.Abs(Number);
        if (Number > 0)
        {
            do
            {
                long A = 0;
                long B = 0;
                A = Number / 1000;
                B = Number % 1000;
                Num.Add(B);
                if (A >= 1000)
                {
                    Number = A;
                }
                else if (A != 0)
                {
                    Num.Add(A);
                    break; // TODO: might not be correct. Was : Exit Do
                }
                else
                {
                    break; // TODO: might not be correct. Was : Exit Do
                }
            } while (true);
        }
        else if (Number == 0)
        {
            return "صفر";
        }
        //---------------------------------------------------'
        for (int I = 0; I <= Num.Count - 1; I++)
        {
            Word.Add(ConvertLongToText(Num[I]));
        }
        //---------------------------------------------------'
        for (int Counter = Word.Count - 1; Counter >= 0; Counter += -1)
        {
            if (Counter == 5)
            {
                if (!string.IsNullOrEmpty(Word[5]))
                {
                    if (!string.IsNullOrEmpty(Word[4]) || !string.IsNullOrEmpty(Word[3]) || !string.IsNullOrEmpty(Word[2]) || !string.IsNullOrEmpty(Word[1]) || !string.IsNullOrEmpty(Word[0]))
                    {
                        Text += Word[5] + " بيليارد و ";
                    }
                    else
                    {
                        Text += Word[5] + " بيليارد";
                        break; // TODO: might not be correct. Was : Exit For
                    }
                }
            }
            else if (Counter == 4)
            {
                if (!string.IsNullOrEmpty(Word[4]))
                {
                    if (!string.IsNullOrEmpty(Word[3]) || !string.IsNullOrEmpty(Word[2]) || !string.IsNullOrEmpty(Word[1]) || !string.IsNullOrEmpty(Word[0]))
                    {
                        Text += Word[4] + " بيليون و ";
                    }
                    else
                    {
                        Text += Word[4] + " بيليون";
                        break; // TODO: might not be correct. Was : Exit For
                    }
                }
            }
            else if (Counter == 3)
            {
                if (!string.IsNullOrEmpty(Word[3]))
                {
                    if (!string.IsNullOrEmpty(Word[2]) || !string.IsNullOrEmpty(Word[1]) || !string.IsNullOrEmpty(Word[0]))
                    {
                        Text += Word[3] + " ميليارد و ";
                    }
                    else
                    {
                        Text += Word[3] + " ميليارد";
                        break; // TODO: might not be correct. Was : Exit For
                    }
                }
            }
            else if (Counter == 2)
            {
                if (!string.IsNullOrEmpty(Word[2]))
                {
                    if (!string.IsNullOrEmpty(Word[1]) || !string.IsNullOrEmpty(Word[0]))
                    {
                        Text += Word[2] + " ميليون و ";
                    }
                    else
                    {
                        Text += Word[2] + " ميليون";
                        break; // TODO: might not be correct. Was : Exit For
                    }
                }
            }
            else if (Counter == 1)
            {
                if (!string.IsNullOrEmpty(Word[1]))
                {
                    if (!string.IsNullOrEmpty(Word[0]))
                    {
                        Text += Word[1] + " هزار و ";
                    }
                    else
                    {
                        Text += Word[1] + " هزار";
                        break; // TODO: might not be correct. Was : Exit For
                    }
                }
            }
            else
            {
                Text += Word[0];
            }
        }
        //---------------------------------------------------'
        return Text;
        //---------------------------------------------------'
    }

    private static string ConvertIntToText(this int Number)
    {
        //---------------------------------------------------'
        List<string> N = new List<string>();
        string Yekan = "";
        string Dahgan = "";
        string Sadgan = "";
        string Value = "";
        //---------------------------------------------------'
        do
        {
            int A = 0;
            int B = 0;
            A = Number / 10;
            B = Number % 10;
            N.Add(Convert.ToString(B));
            if (A >= 10)
            {
                Number = A;
            }
            else
            {
                N.Add(Convert.ToString(A));
                break; // TODO: might not be correct. Was : Exit Do
            }
        } while (true);
        //---------------------------------------------------'
        if (N.Count == 3)
        {
            switch (N[2])
            {
                case "0":
                    Sadgan = "";
                    break;
                case "1":
                    Sadgan = "صد";
                    break;
                case "2":
                    Sadgan = "دويست";
                    break;
                case "3":
                    Sadgan = "سيصد";
                    break;
                case "4":
                    Sadgan = "چهارصد";
                    break;
                case "5":
                    Sadgan = "پانصد";
                    break;
                case "6":
                    Sadgan = "ششصد";
                    break;
                case "7":
                    Sadgan = "هفتصد";
                    break;
                case "8":
                    Sadgan = "هشتصد";
                    break;
                case "9":
                    Sadgan = "نهصد";
                    break;
            }
        }
        //---------------------------------------------------'
        switch (N[0])
        {
            case "0":
                Yekan = "";
                break;
            case "1":
                Yekan = "يك";
                break;
            case "2":
                Yekan = "دو";
                break;
            case "3":
                Yekan = "سه";
                break;
            case "4":
                Yekan = "چهار";
                break;
            case "5":
                Yekan = "پنج";
                break;
            case "6":
                Yekan = "شش";
                break;
            case "7":
                Yekan = "هفت";
                break;
            case "8":
                Yekan = "هشت";
                break;
            case "9":
                Yekan = "نه";
                break;
        }
        //---------------------------------------------------'
        switch (N[1])
        {
            case "0":
                Dahgan = "";
                break;
            case "1":
                switch (N[0])
                {
                    case "0":
                        Yekan = "ده";
                        break;
                    case "1":
                        Yekan = "يازده";
                        break;
                    case "2":
                        Yekan = "دوازده";
                        break;
                    case "3":
                        Yekan = "سيزده";
                        break;
                    case "4":
                        Yekan = "چهارده";
                        break;
                    case "5":
                        Yekan = "پانزده";
                        break;
                    case "6":
                        Yekan = "شانزده";
                        break;
                    case "7":
                        Yekan = "هفده";
                        break;
                    case "8":
                        Yekan = "هيجده";
                        break;
                    case "9":
                        Yekan = "نوزده";
                        break;
                }
                break; // TODO: might not be correct. Was : Exit Select


            case "2":
                Dahgan = "بيست";
                break;
            case "3":
                Dahgan = "سي";
                break;
            case "4":
                Dahgan = "چهل";
                break;
            case "5":
                Dahgan = "پنجاه";
                break;
            case "6":
                Dahgan = "شصت";
                break;
            case "7":
                Dahgan = "هفتاد";
                break;
            case "8":
                Dahgan = "هشتاد";
                break;
            case "9":
                Dahgan = "نود";
                break;
        }
        //---------------------------------------------------'
        if (!string.IsNullOrEmpty(Sadgan))
        {
            Value += Sadgan;
            if (!string.IsNullOrEmpty(Dahgan))
            {
                Value += " و " + Dahgan;
                if (!string.IsNullOrEmpty(Yekan))
                {
                    Value += " و " + Yekan;
                }
            }
            else if (!string.IsNullOrEmpty(Yekan))
            {
                Value += " و " + Yekan;
            }
        }
        else if (!string.IsNullOrEmpty(Dahgan))
        {
            Value += Dahgan;
            if (!string.IsNullOrEmpty(Yekan))
            {
                Value += " و " + Yekan;
            }
        }
        else
        {
            Value += Yekan;
        }
        //---------------------------------------------------'
        return Value;
        //---------------------------------------------------'
    }
    public static string FixFarsiProblem(this string str)
    {
        if (str == null)
        {
            return str;
        }
        return str.ToString().Replace("ك", "ک").Replace("ي", "ی");
    }

    public static string ReplaceWithOutSpace(this string str)
    {
        if (str == null)
        {
            return str;
        }
        return str.FixFarsiProblem().Replace(" ", "").Trim();
    }

    public static string ReplaceEnglishNumberToPersian(this string file)
    {
        char[] ch = file.ToCharArray();
        string tmp = string.Empty;
        foreach (char tmpch in ch)
        {
            switch (tmpch)
            {
                case '0':
                    tmp = string.Format("{0}&#1776;", tmp);
                    break; // TODO: might not be correct. Was : Exit Select


                case '1':
                    tmp = string.Format("{0}&#1777;", tmp);
                    break; // TODO: might not be correct. Was : Exit Select


                case '2':
                    tmp = string.Format("{0}&#1778;", tmp);
                    break; // TODO: might not be correct. Was : Exit Select


                case '3':
                    tmp = string.Format("{0}&#1779;", tmp);
                    break; // TODO: might not be correct. Was : Exit Select


                case '4':
                    tmp = string.Format("{0}&#1780;", tmp);
                    break; // TODO: might not be correct. Was : Exit Select


                case '5':
                    tmp = string.Format("{0}&#1781;", tmp);
                    break; // TODO: might not be correct. Was : Exit Select


                case '6':
                    tmp = string.Format("{0}&#1782;", tmp);
                    break; // TODO: might not be correct. Was : Exit Select


                case '7':
                    tmp = string.Format("{0}&#1783;", tmp);
                    break; // TODO: might not be correct. Was : Exit Select


                case '8':
                    tmp = string.Format("{0}&#1784;", tmp);
                    break; // TODO: might not be correct. Was : Exit Select


                case '9':
                    tmp = string.Format("{0}&#1785;", tmp);
                    break; // TODO: might not be correct. Was : Exit Select


                default:
                    tmp = string.Format("{0}{1}", tmp, tmpch);
                    break; // TODO: might not be correct. Was : Exit Select




            }
        }
        return tmp;

    }

    public static string ReplacePersianPrantes(this string file)
    {
        char[] ch = file.ToCharArray();
        string tmp = string.Empty;
        foreach (char tmpch in ch)
        {
            switch (tmpch)
            {
                case '(':
                    tmp = string.Format("{0})", tmp);
                    break; // TODO: might not be correct. Was : Exit Select

                case ')':
                    tmp = string.Format("{0}(", tmp);
                    break; // TODO: might not be correct. Was : Exit Select

                default:
                    tmp = string.Format("{0}{1}", tmp, tmpch);

                    break;

            }
        }
        return tmp;

    }
    public static string Reverse_String1(this string instr)
    {
        string functionReturnValue = null;
        int i = 0;
        //Dim j As Integer
        string ch = null;
        string tempstr = null;
        tempstr = "";
        functionReturnValue = "";
        for (i = instr.Length; i >= 1; i += -1)
        {
            ch = instr.Substring(i, 1);
            if (ch == "/")
            {
                functionReturnValue = functionReturnValue + Reverse_String(tempstr) + "/";
                tempstr = "";
                // i = i - 1
            }
            else
            {
                tempstr = tempstr + ch;
            }
        }
        functionReturnValue = functionReturnValue + Reverse_String(tempstr);
        tempstr = functionReturnValue;
        // Reverse_String1 = Left(tempstr, tempstr.Length - 1)
        return functionReturnValue;

    }

    public static string Reverse_String(this string Instr)
    {
        string functionReturnValue = null;
        int i = 0;
        functionReturnValue = "";
        for (i = Instr.Length; i >= 1; i += -1)
        {
            functionReturnValue = functionReturnValue + Instr.Substring(i, 1);
        }
        return functionReturnValue;

    }

    public static string Reverse_Pelak(this string instr)
    {
        string functionReturnValue = null;
        int i = 0;
        //Dim j As Integer
        string ch = null;
        string tempstr = null;
        tempstr = "";
        functionReturnValue = "";
        for (i = instr.Length; i >= 1; i += -1)
        {
            ch = instr.Substring(i, 1);
            if (!ch.IsNumericData())
            {
                functionReturnValue = functionReturnValue + Reverse_String(tempstr) + ch;
                tempstr = "";
                // i = i - 1
            }
            else
            {
                tempstr = tempstr + ch;
            }
        }
        functionReturnValue = functionReturnValue + Reverse_String(tempstr);
        tempstr = functionReturnValue;
        // Reverse_String1 = Left(tempstr, tempstr.Length - 1)
        return functionReturnValue;

    }
}
}
