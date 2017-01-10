﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Security.Cryptography;
using System.Text;

namespace SeHydra.Security
{
    public class FingerPrint
    {
        private static string _fingerPrint = string.Empty;
        public static string Value()
        {
            if (string.IsNullOrEmpty(_fingerPrint))
            {
                _fingerPrint = GetHash("\nBIOS >> " +
                                      BiosId() + "\nBASE >> " + BaseId() +
                                      "\nMAC >> " + MacId());
            }
            return _fingerPrint;
        }
        private static string GetHash(string s)
        {
            var sec = new MD5CryptoServiceProvider();
            var enc = new ASCIIEncoding();
            var bt = enc.GetBytes(s);
            return GetHexString(sec.ComputeHash(bt));
        }
        private static string GetHexString(IList<byte> bt)
        {
            var s = string.Empty;
            for (var i = 0; i < bt.Count; i++)
            {
                var b = bt[i];
                var n = (int)b;
                var n1 = n & 15;
                var n2 = (n >> 4) & 15;
                if (n2 > 9)
                    s += ((char)(n2 - 10 + 'A')).ToString();
                else
                    s += n2.ToString();
                if (n1 > 9)
                    s += ((char)(n1 - 10 + 'A')).ToString();
                else
                    s += n1.ToString();
                if ((i + 1) != bt.Count && (i + 1) % 2 == 0) s += "-";
            }
            return s;
        }
        #region Original Device ID Getting Code
        //Return a hardware identifier
        private static string Identifier(string wmiClass, string wmiProperty, string wmiMustBeTrue)
        {
            string[] result = { "" };
            var mc = new ManagementClass(wmiClass);
            var moc = mc.GetInstances();
            foreach (var mo in from ManagementObject mo in moc
                               where mo[wmiMustBeTrue].ToString()
                                   == "True"
                               where result[0] == ""
                               select mo)
            {
                try
                {
                    result[0] = mo[wmiProperty].ToString();
                    break;
                }
                catch (Exception e)
                {
                    Console.WriteLine(@"Indent " + e.Message);
                }
            }
            return result[0];
        }
        //Return a hardware identifier
        private static string Identifier(string wmiClass, string wmiProperty)
        {
            string[] result = { "" };
            var mc = new ManagementClass(wmiClass);
            var moc = mc.GetInstances();
            foreach (var mo in moc.Cast<ManagementObject>().Where(mo => result[0] == ""))
            {
                try
                {
                    result[0] = mo[wmiProperty].ToString();
                    break;
                }
                catch (Exception e)
                {
                    Console.WriteLine(@"Indent2 " + e.Message);
                }
            }
            return result[0];
        }
        /*private static string CpuId()
         {
             //Uses first CPU identifier available in order of preference
             //Don't get all identifiers, as it is very time consuming
             string retVal = Identifier("Win32_Processor", "UniqueId");
             if (retVal == "") //If no UniqueID, use ProcessorID
             {
                 retVal = Identifier("Win32_Processor", "ProcessorId");
                 if (retVal == "") //If no ProcessorId, use Name
                 {
                     retVal = Identifier("Win32_Processor", "Name");
                     if (retVal == "") //If no Name, use Manufacturer
                     {
                         retVal = Identifier("Win32_Processor", "Manufacturer");
                     }
                     //Add clock speed for extra security
                     retVal += Identifier("Win32_Processor", "MaxClockSpeed");
                 }
             }
             return retVal;
         }*/
        //BIOS Identifier
        private static string BiosId()
        {
            return Identifier("Win32_BIOS", "Manufacturer")
            + Identifier("Win32_BIOS", "SMBIOSBIOSVersion")
            + Identifier("Win32_BIOS", "IdentificationCode")
            + Identifier("Win32_BIOS", "SerialNumber")
            + Identifier("Win32_BIOS", "ReleaseDate")
            + Identifier("Win32_BIOS", "Version");
        }
        //Main physical hard drive ID
        /*private static string DiskId()
        {
            return Identifier("Win32_DiskDrive", "Model")
            + Identifier("Win32_DiskDrive", "Manufacturer")
            + Identifier("Win32_DiskDrive", "Signature")
            + Identifier("Win32_DiskDrive", "TotalHeads");
        }*/
        //Motherboard ID
        private static string BaseId()
        {
            return Identifier("Win32_BaseBoard", "Model")
            + Identifier("Win32_BaseBoard", "Manufacturer")
            + Identifier("Win32_BaseBoard", "Name")
            + Identifier("Win32_BaseBoard", "SerialNumber");
        }
        //Primary video controller ID
        /*private static string VideoId()
        {
            return Identifier("Win32_VideoController", "DriverVersion")
            + Identifier("Win32_VideoController", "Name");
        }*/
        //First enabled network card ID
        private static string MacId()
        {
            return Identifier("Win32_NetworkAdapterConfiguration",
                "MACAddress", "IPEnabled");
        }
        #endregion
    }
}
