using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Common;

namespace Restful
{

    // 擴充方法
    public static class PropertyExtension
    {
        public static void SetPropertyValue(this object obj, string propName, object value)
        {
            obj.GetType().GetProperty(propName).SetValue(obj, value, null);
        }

        public static object GetPropertyValue(this object obj, string propName)
        {
            return obj.GetType().GetProperty(propName).GetValue(obj, null);
        }
    }

    public class IOT_DbContext : DbContext
    {
        static DbConnection CreateDbConnection(string providerName, string connectionString)
        {
            // Assume failure.
            DbConnection connection = null;

            // Create the DbProviderFactory and DbConnection.
            if (connectionString != null)
            {
                try
                {
                    DbProviderFactory factory = DbProviderFactories.GetFactory(providerName);

                    connection = factory.CreateConnection();
                    connection.ConnectionString = connectionString;
                }
                catch (Exception ex)
                {
                    // Set the connection to null if it was created.
                    if (connection != null)
                    {
                        connection = null;
                    }
                    Console.WriteLine(ex.Message);
                }
            }
            // Return the connection.
            return connection;
        }

        // Constructor 
        public IOT_DbContext(string provider, string connectstring) : base(CreateDbConnection(provider, connectstring), true)
        {
        }


        public virtual DbSet<IOT_GATEWAY> IOT_Gateway { get; set; }
        public virtual DbSet<IOT_DEVICE> IOT_Device { get; set; }
        public virtual DbSet<IOT_DEVICE_EDC_LABEL> IOT_Device_EDC_Label { get; set; }

        public virtual DbSet<IOT_DEVICE_EDC_001> IOT_DEVICE_EDC_001 { get; set; }
        public virtual DbSet<IOT_DEVICE_EDC_002> IOT_DEVICE_EDC_002 { get; set; }
        public virtual DbSet<IOT_DEVICE_EDC_003> IOT_DEVICE_EDC_003 { get; set; }
        public virtual DbSet<IOT_DEVICE_EDC_004> IOT_DEVICE_EDC_004 { get; set; }
        public virtual DbSet<IOT_DEVICE_EDC_005> IOT_DEVICE_EDC_005 { get; set; }
        public virtual DbSet<IOT_DEVICE_EDC_006> IOT_DEVICE_EDC_006 { get; set; }
        public virtual DbSet<IOT_DEVICE_EDC_007> IOT_DEVICE_EDC_007 { get; set; }
        public virtual DbSet<IOT_DEVICE_EDC_008> IOT_DEVICE_EDC_008 { get; set; }
        public virtual DbSet<IOT_DEVICE_EDC_009> IOT_DEVICE_EDC_009 { get; set; }
        public virtual DbSet<IOT_DEVICE_EDC_010> IOT_DEVICE_EDC_010 { get; set; }
        public virtual DbSet<IOT_DEVICE_EDC_011> IOT_DEVICE_EDC_011 { get; set; }
        public virtual DbSet<IOT_DEVICE_EDC_012> IOT_DEVICE_EDC_012 { get; set; }
        public virtual DbSet<IOT_DEVICE_EDC_013> IOT_DEVICE_EDC_013 { get; set; }
        public virtual DbSet<IOT_DEVICE_EDC_014> IOT_DEVICE_EDC_014 { get; set; }
        public virtual DbSet<IOT_DEVICE_EDC_015> IOT_DEVICE_EDC_015 { get; set; }
        public virtual DbSet<IOT_DEVICE_EDC_016> IOT_DEVICE_EDC_016 { get; set; }
        public virtual DbSet<IOT_DEVICE_EDC_017> IOT_DEVICE_EDC_017 { get; set; }
        public virtual DbSet<IOT_DEVICE_EDC_018> IOT_DEVICE_EDC_018 { get; set; }
        public virtual DbSet<IOT_DEVICE_EDC_019> IOT_DEVICE_EDC_019 { get; set; }
        public virtual DbSet<IOT_DEVICE_EDC_020> IOT_DEVICE_EDC_020 { get; set; }
        public virtual DbSet<IOT_DEVICE_EDC_021> IOT_DEVICE_EDC_021 { get; set; }
        public virtual DbSet<IOT_DEVICE_EDC_022> IOT_DEVICE_EDC_022 { get; set; }
        public virtual DbSet<IOT_DEVICE_EDC_023> IOT_DEVICE_EDC_023 { get; set; }
        public virtual DbSet<IOT_DEVICE_EDC_024> IOT_DEVICE_EDC_024 { get; set; }
        public virtual DbSet<IOT_DEVICE_EDC_025> IOT_DEVICE_EDC_025 { get; set; }
        public virtual DbSet<IOT_DEVICE_EDC_026> IOT_DEVICE_EDC_026 { get; set; }
        public virtual DbSet<IOT_DEVICE_EDC_027> IOT_DEVICE_EDC_027 { get; set; }
        public virtual DbSet<IOT_DEVICE_EDC_028> IOT_DEVICE_EDC_028 { get; set; }
        public virtual DbSet<IOT_DEVICE_EDC_029> IOT_DEVICE_EDC_029 { get; set; }
        public virtual DbSet<IOT_DEVICE_EDC_030> IOT_DEVICE_EDC_030 { get; set; }
        public virtual DbSet<IOT_DEVICE_EDC_031> IOT_DEVICE_EDC_031 { get; set; }
        public virtual DbSet<IOT_DEVICE_EDC_032> IOT_DEVICE_EDC_032 { get; set; }
        public virtual DbSet<IOT_DEVICE_EDC_033> IOT_DEVICE_EDC_033 { get; set; }
        public virtual DbSet<IOT_DEVICE_EDC_034> IOT_DEVICE_EDC_034 { get; set; }
        public virtual DbSet<IOT_DEVICE_EDC_035> IOT_DEVICE_EDC_035 { get; set; }
        public virtual DbSet<IOT_DEVICE_EDC_036> IOT_DEVICE_EDC_036 { get; set; }
        public virtual DbSet<IOT_DEVICE_EDC_037> IOT_DEVICE_EDC_037 { get; set; }
        public virtual DbSet<IOT_DEVICE_EDC_038> IOT_DEVICE_EDC_038 { get; set; }
        public virtual DbSet<IOT_DEVICE_EDC_039> IOT_DEVICE_EDC_039 { get; set; }
        public virtual DbSet<IOT_DEVICE_EDC_040> IOT_DEVICE_EDC_040 { get; set; }
        public virtual DbSet<IOT_DEVICE_EDC_041> IOT_DEVICE_EDC_041 { get; set; }
        public virtual DbSet<IOT_DEVICE_EDC_042> IOT_DEVICE_EDC_042 { get; set; }
        public virtual DbSet<IOT_DEVICE_EDC_043> IOT_DEVICE_EDC_043 { get; set; }
        public virtual DbSet<IOT_DEVICE_EDC_044> IOT_DEVICE_EDC_044 { get; set; }
        public virtual DbSet<IOT_DEVICE_EDC_045> IOT_DEVICE_EDC_045 { get; set; }
        public virtual DbSet<IOT_DEVICE_EDC_046> IOT_DEVICE_EDC_046 { get; set; }
        public virtual DbSet<IOT_DEVICE_EDC_047> IOT_DEVICE_EDC_047 { get; set; }
        public virtual DbSet<IOT_DEVICE_EDC_048> IOT_DEVICE_EDC_048 { get; set; }
        public virtual DbSet<IOT_DEVICE_EDC_049> IOT_DEVICE_EDC_049 { get; set; }
        public virtual DbSet<IOT_DEVICE_EDC_050> IOT_DEVICE_EDC_050 { get; set; }
        public virtual DbSet<IOT_DEVICE_EDC_051> IOT_DEVICE_EDC_051 { get; set; }
        public virtual DbSet<IOT_DEVICE_EDC_052> IOT_DEVICE_EDC_052 { get; set; }
        public virtual DbSet<IOT_DEVICE_EDC_053> IOT_DEVICE_EDC_053 { get; set; }
        public virtual DbSet<IOT_DEVICE_EDC_054> IOT_DEVICE_EDC_054 { get; set; }
        public virtual DbSet<IOT_DEVICE_EDC_055> IOT_DEVICE_EDC_055 { get; set; }
        public virtual DbSet<IOT_DEVICE_EDC_056> IOT_DEVICE_EDC_056 { get; set; }
        public virtual DbSet<IOT_DEVICE_EDC_057> IOT_DEVICE_EDC_057 { get; set; }
        public virtual DbSet<IOT_DEVICE_EDC_058> IOT_DEVICE_EDC_058 { get; set; }
        public virtual DbSet<IOT_DEVICE_EDC_059> IOT_DEVICE_EDC_059 { get; set; }
        public virtual DbSet<IOT_DEVICE_EDC_060> IOT_DEVICE_EDC_060 { get; set; }
        public virtual DbSet<IOT_DEVICE_EDC_061> IOT_DEVICE_EDC_061 { get; set; }
        public virtual DbSet<IOT_DEVICE_EDC_062> IOT_DEVICE_EDC_062 { get; set; }
        public virtual DbSet<IOT_DEVICE_EDC_063> IOT_DEVICE_EDC_063 { get; set; }
        public virtual DbSet<IOT_DEVICE_EDC_064> IOT_DEVICE_EDC_064 { get; set; }
        public virtual DbSet<IOT_DEVICE_EDC_065> IOT_DEVICE_EDC_065 { get; set; }
        public virtual DbSet<IOT_DEVICE_EDC_066> IOT_DEVICE_EDC_066 { get; set; }
        public virtual DbSet<IOT_DEVICE_EDC_067> IOT_DEVICE_EDC_067 { get; set; }
        public virtual DbSet<IOT_DEVICE_EDC_068> IOT_DEVICE_EDC_068 { get; set; }
        public virtual DbSet<IOT_DEVICE_EDC_069> IOT_DEVICE_EDC_069 { get; set; }
        public virtual DbSet<IOT_DEVICE_EDC_070> IOT_DEVICE_EDC_070 { get; set; }
        public virtual DbSet<IOT_DEVICE_EDC_071> IOT_DEVICE_EDC_071 { get; set; }
        public virtual DbSet<IOT_DEVICE_EDC_072> IOT_DEVICE_EDC_072 { get; set; }
        public virtual DbSet<IOT_DEVICE_EDC_073> IOT_DEVICE_EDC_073 { get; set; }
        public virtual DbSet<IOT_DEVICE_EDC_074> IOT_DEVICE_EDC_074 { get; set; }
        public virtual DbSet<IOT_DEVICE_EDC_075> IOT_DEVICE_EDC_075 { get; set; }
        public virtual DbSet<IOT_DEVICE_EDC_076> IOT_DEVICE_EDC_076 { get; set; }
        public virtual DbSet<IOT_DEVICE_EDC_077> IOT_DEVICE_EDC_077 { get; set; }
        public virtual DbSet<IOT_DEVICE_EDC_078> IOT_DEVICE_EDC_078 { get; set; }
        public virtual DbSet<IOT_DEVICE_EDC_079> IOT_DEVICE_EDC_079 { get; set; }
        public virtual DbSet<IOT_DEVICE_EDC_080> IOT_DEVICE_EDC_080 { get; set; }
        public virtual DbSet<IOT_DEVICE_EDC_081> IOT_DEVICE_EDC_081 { get; set; }
        public virtual DbSet<IOT_DEVICE_EDC_082> IOT_DEVICE_EDC_082 { get; set; }
        public virtual DbSet<IOT_DEVICE_EDC_083> IOT_DEVICE_EDC_083 { get; set; }
        public virtual DbSet<IOT_DEVICE_EDC_084> IOT_DEVICE_EDC_084 { get; set; }
        public virtual DbSet<IOT_DEVICE_EDC_085> IOT_DEVICE_EDC_085 { get; set; }
        public virtual DbSet<IOT_DEVICE_EDC_086> IOT_DEVICE_EDC_086 { get; set; }
        public virtual DbSet<IOT_DEVICE_EDC_087> IOT_DEVICE_EDC_087 { get; set; }
        public virtual DbSet<IOT_DEVICE_EDC_088> IOT_DEVICE_EDC_088 { get; set; }
        public virtual DbSet<IOT_DEVICE_EDC_089> IOT_DEVICE_EDC_089 { get; set; }
        public virtual DbSet<IOT_DEVICE_EDC_090> IOT_DEVICE_EDC_090 { get; set; }
        public virtual DbSet<IOT_DEVICE_EDC_091> IOT_DEVICE_EDC_091 { get; set; }
        public virtual DbSet<IOT_DEVICE_EDC_092> IOT_DEVICE_EDC_092 { get; set; }
        public virtual DbSet<IOT_DEVICE_EDC_093> IOT_DEVICE_EDC_093 { get; set; }
        public virtual DbSet<IOT_DEVICE_EDC_094> IOT_DEVICE_EDC_094 { get; set; }
        public virtual DbSet<IOT_DEVICE_EDC_095> IOT_DEVICE_EDC_095 { get; set; }
        public virtual DbSet<IOT_DEVICE_EDC_096> IOT_DEVICE_EDC_096 { get; set; }
        public virtual DbSet<IOT_DEVICE_EDC_097> IOT_DEVICE_EDC_097 { get; set; }
        public virtual DbSet<IOT_DEVICE_EDC_098> IOT_DEVICE_EDC_098 { get; set; }
        public virtual DbSet<IOT_DEVICE_EDC_099> IOT_DEVICE_EDC_099 { get; set; }
        public virtual DbSet<IOT_DEVICE_EDC_100> IOT_DEVICE_EDC_100 { get; set; }
        public virtual DbSet<IOT_DEVICE_EDC_101> IOT_DEVICE_EDC_101 { get; set; }
        public virtual DbSet<IOT_DEVICE_EDC_102> IOT_DEVICE_EDC_102 { get; set; }
        public virtual DbSet<IOT_DEVICE_EDC_103> IOT_DEVICE_EDC_103 { get; set; }
        public virtual DbSet<IOT_DEVICE_EDC_104> IOT_DEVICE_EDC_104 { get; set; }
        public virtual DbSet<IOT_DEVICE_EDC_105> IOT_DEVICE_EDC_105 { get; set; }
        public virtual DbSet<IOT_DEVICE_EDC_106> IOT_DEVICE_EDC_106 { get; set; }
        public virtual DbSet<IOT_DEVICE_EDC_107> IOT_DEVICE_EDC_107 { get; set; }
        public virtual DbSet<IOT_DEVICE_EDC_108> IOT_DEVICE_EDC_108 { get; set; }
        public virtual DbSet<IOT_DEVICE_EDC_109> IOT_DEVICE_EDC_109 { get; set; }
        public virtual DbSet<IOT_DEVICE_EDC_110> IOT_DEVICE_EDC_110 { get; set; }
        public virtual DbSet<IOT_DEVICE_EDC_111> IOT_DEVICE_EDC_111 { get; set; }
        public virtual DbSet<IOT_DEVICE_EDC_112> IOT_DEVICE_EDC_112 { get; set; }
        public virtual DbSet<IOT_DEVICE_EDC_113> IOT_DEVICE_EDC_113 { get; set; }
        public virtual DbSet<IOT_DEVICE_EDC_114> IOT_DEVICE_EDC_114 { get; set; }
        public virtual DbSet<IOT_DEVICE_EDC_115> IOT_DEVICE_EDC_115 { get; set; }
        public virtual DbSet<IOT_DEVICE_EDC_116> IOT_DEVICE_EDC_116 { get; set; }
        public virtual DbSet<IOT_DEVICE_EDC_117> IOT_DEVICE_EDC_117 { get; set; }
        public virtual DbSet<IOT_DEVICE_EDC_118> IOT_DEVICE_EDC_118 { get; set; }
        public virtual DbSet<IOT_DEVICE_EDC_119> IOT_DEVICE_EDC_119 { get; set; }
        public virtual DbSet<IOT_DEVICE_EDC_120> IOT_DEVICE_EDC_120 { get; set; }
        public virtual DbSet<IOT_DEVICE_EDC_121> IOT_DEVICE_EDC_121 { get; set; }
        public virtual DbSet<IOT_DEVICE_EDC_122> IOT_DEVICE_EDC_122 { get; set; }
        public virtual DbSet<IOT_DEVICE_EDC_123> IOT_DEVICE_EDC_123 { get; set; }
        public virtual DbSet<IOT_DEVICE_EDC_124> IOT_DEVICE_EDC_124 { get; set; }
        public virtual DbSet<IOT_DEVICE_EDC_125> IOT_DEVICE_EDC_125 { get; set; }
        public virtual DbSet<IOT_DEVICE_EDC_126> IOT_DEVICE_EDC_126 { get; set; }
        public virtual DbSet<IOT_DEVICE_EDC_127> IOT_DEVICE_EDC_127 { get; set; }
        public virtual DbSet<IOT_DEVICE_EDC_128> IOT_DEVICE_EDC_128 { get; set; }


    }

    public class IOT_GATEWAY
    {
        public int id { get; set; }
        public string gateway_id { get; set; }
        public string gateway_ip { get; set; }
        public string location { get; set; }
        public string virtual_flag { get; set; }
        public string virtual_publish_topic { get; set; }
        public DateTime clm_date_time { get; set; }
        public string clm_user { get; set; }

        public IOT_GATEWAY() { }

    }

    public class IOT_DEVICE
    {
        public int id { get; set; }
        public string device_id { get; set; }
        public string device_desc { get; set; }
        public string device_type { get; set; }
        public string status { get; set; }
        public string location { get; set; }
        public double value { get; set; }
        public double lcl { get; set; }
        public double ucl { get; set; }
        public double lspec { get; set; }
        public double uspec { get; set; }
        public DateTime clm_date_time { get; set; }
        public string clm_user { get; set; }
        public int rpt_interval { get; set; }
        public int col_interval { get; set; }
        public string ooc_flg { get; set; }
        public string oos_flg { get; set; }
        public string alarm_flg { get; set; }
        public string eqp_id { get; set; }
        public string sub_eqp_id { get; set; }
        public int device_no { get; set; }
        public double pos_latitude { get; set; }
        public double pos_longitude { get; set; }
        public string gateway_id { get; set; }
        public string plc_ip_address { get; set; }
        public string plc_port_id { get; set; }
        public string ble_mac { get; set; }
        public string ble_service_uuid { get; set; }


        public IOT_DEVICE() { }
    }

    public class IOT_STATUS_MONITOR
    {
        public int id { get; set; }
        public string gateway_id { get; set; }
        public string device_id { get; set; }
        public string device_type { get; set; }
        public string virtual_flag { get; set; }
        public string plc_ip { get; set; }
        public string plc_port { get; set; }
        public string device_status { get; set; }
        public string iotclient_status { get; set; }
        public string hb_status { get; set; }
        public string device_location { get; set; }
        public DateTime last_edc_time { get; set; }
        public DateTime hb_report_time { get; set; }
        public string last_alarm_code { get; set; }
        public string last_alarm_app { get; set; }
        public string last_alarm_message { get; set; }
        public DateTime last_alarm_datetime { get; set; }

        public IOT_STATUS_MONITOR()
        {
        }
    }

    public class IOT_DEVICE_EDC_LABEL
    {
        public int id { get; set; }
        public string device_id { get; set; }
        public string data_name { get; set; }
        public double lcl { get; set; }
        public double ucl { get; set; }
        public double lspec { get; set; }
        public double uspec { get; set; }
        public int data_index { get; set; }
        public DateTime clm_date_time { get; set; }
        public string clm_user { get; set; }

        public IOT_DEVICE_EDC_LABEL()
        {


        }
    }


    public class IOT_DEVICE_EDC_001
    {

        public int id { get; set; }
        public string device_id { get; set; }
        public string data_value_01 { get; set; }
        public string data_value_02 { get; set; }
        public string data_value_03 { get; set; }
        public string data_value_04 { get; set; }
        public string data_value_05 { get; set; }
        public string data_value_06 { get; set; }
        public string data_value_07 { get; set; }
        public string data_value_08 { get; set; }
        public string data_value_09 { get; set; }
        public string data_value_10 { get; set; }
        public string data_value_11 { get; set; }
        public string data_value_12 { get; set; }
        public string data_value_13 { get; set; }
        public string data_value_14 { get; set; }
        public string data_value_15 { get; set; }
        public string data_value_16 { get; set; }
        public string data_value_17 { get; set; }
        public string data_value_18 { get; set; }
        public string data_value_19 { get; set; }
        public string data_value_20 { get; set; }
        public string data_value_21 { get; set; }
        public string data_value_22 { get; set; }
        public string data_value_23 { get; set; }
        public string data_value_24 { get; set; }
        public string data_value_25 { get; set; }
        public string data_value_26 { get; set; }
        public string data_value_27 { get; set; }
        public string data_value_28 { get; set; }
        public string data_value_29 { get; set; }
        public string data_value_30 { get; set; }
        public string data_value_31 { get; set; }
        public string data_value_32 { get; set; }
        public string data_value_33 { get; set; }
        public string data_value_34 { get; set; }
        public string data_value_35 { get; set; }
        public string data_value_36 { get; set; }
        public string data_value_37 { get; set; }
        public string data_value_38 { get; set; }
        public string data_value_39 { get; set; }
        public string data_value_40 { get; set; }
        public DateTime clm_date_time { get; set; }
        public string clm_user { get; set; }

    }
    public class IOT_DEVICE_EDC_002
    {

        public int id { get; set; }
        public string device_id { get; set; }
        public string data_value_01 { get; set; }
        public string data_value_02 { get; set; }
        public string data_value_03 { get; set; }
        public string data_value_04 { get; set; }
        public string data_value_05 { get; set; }
        public string data_value_06 { get; set; }
        public string data_value_07 { get; set; }
        public string data_value_08 { get; set; }
        public string data_value_09 { get; set; }
        public string data_value_10 { get; set; }
        public string data_value_11 { get; set; }
        public string data_value_12 { get; set; }
        public string data_value_13 { get; set; }
        public string data_value_14 { get; set; }
        public string data_value_15 { get; set; }
        public string data_value_16 { get; set; }
        public string data_value_17 { get; set; }
        public string data_value_18 { get; set; }
        public string data_value_19 { get; set; }
        public string data_value_20 { get; set; }
        public string data_value_21 { get; set; }
        public string data_value_22 { get; set; }
        public string data_value_23 { get; set; }
        public string data_value_24 { get; set; }
        public string data_value_25 { get; set; }
        public string data_value_26 { get; set; }
        public string data_value_27 { get; set; }
        public string data_value_28 { get; set; }
        public string data_value_29 { get; set; }
        public string data_value_30 { get; set; }
        public string data_value_31 { get; set; }
        public string data_value_32 { get; set; }
        public string data_value_33 { get; set; }
        public string data_value_34 { get; set; }
        public string data_value_35 { get; set; }
        public string data_value_36 { get; set; }
        public string data_value_37 { get; set; }
        public string data_value_38 { get; set; }
        public string data_value_39 { get; set; }
        public string data_value_40 { get; set; }
        public DateTime clm_date_time { get; set; }
        public string clm_user { get; set; }

    }
    public class IOT_DEVICE_EDC_003
    {

        public int id { get; set; }
        public string device_id { get; set; }
        public string data_value_01 { get; set; }
        public string data_value_02 { get; set; }
        public string data_value_03 { get; set; }
        public string data_value_04 { get; set; }
        public string data_value_05 { get; set; }
        public string data_value_06 { get; set; }
        public string data_value_07 { get; set; }
        public string data_value_08 { get; set; }
        public string data_value_09 { get; set; }
        public string data_value_10 { get; set; }
        public string data_value_11 { get; set; }
        public string data_value_12 { get; set; }
        public string data_value_13 { get; set; }
        public string data_value_14 { get; set; }
        public string data_value_15 { get; set; }
        public string data_value_16 { get; set; }
        public string data_value_17 { get; set; }
        public string data_value_18 { get; set; }
        public string data_value_19 { get; set; }
        public string data_value_20 { get; set; }
        public string data_value_21 { get; set; }
        public string data_value_22 { get; set; }
        public string data_value_23 { get; set; }
        public string data_value_24 { get; set; }
        public string data_value_25 { get; set; }
        public string data_value_26 { get; set; }
        public string data_value_27 { get; set; }
        public string data_value_28 { get; set; }
        public string data_value_29 { get; set; }
        public string data_value_30 { get; set; }
        public string data_value_31 { get; set; }
        public string data_value_32 { get; set; }
        public string data_value_33 { get; set; }
        public string data_value_34 { get; set; }
        public string data_value_35 { get; set; }
        public string data_value_36 { get; set; }
        public string data_value_37 { get; set; }
        public string data_value_38 { get; set; }
        public string data_value_39 { get; set; }
        public string data_value_40 { get; set; }
        public DateTime clm_date_time { get; set; }
        public string clm_user { get; set; }

    }
    public class IOT_DEVICE_EDC_004
    {

        public int id { get; set; }
        public string device_id { get; set; }
        public string data_value_01 { get; set; }
        public string data_value_02 { get; set; }
        public string data_value_03 { get; set; }
        public string data_value_04 { get; set; }
        public string data_value_05 { get; set; }
        public string data_value_06 { get; set; }
        public string data_value_07 { get; set; }
        public string data_value_08 { get; set; }
        public string data_value_09 { get; set; }
        public string data_value_10 { get; set; }
        public string data_value_11 { get; set; }
        public string data_value_12 { get; set; }
        public string data_value_13 { get; set; }
        public string data_value_14 { get; set; }
        public string data_value_15 { get; set; }
        public string data_value_16 { get; set; }
        public string data_value_17 { get; set; }
        public string data_value_18 { get; set; }
        public string data_value_19 { get; set; }
        public string data_value_20 { get; set; }
        public string data_value_21 { get; set; }
        public string data_value_22 { get; set; }
        public string data_value_23 { get; set; }
        public string data_value_24 { get; set; }
        public string data_value_25 { get; set; }
        public string data_value_26 { get; set; }
        public string data_value_27 { get; set; }
        public string data_value_28 { get; set; }
        public string data_value_29 { get; set; }
        public string data_value_30 { get; set; }
        public string data_value_31 { get; set; }
        public string data_value_32 { get; set; }
        public string data_value_33 { get; set; }
        public string data_value_34 { get; set; }
        public string data_value_35 { get; set; }
        public string data_value_36 { get; set; }
        public string data_value_37 { get; set; }
        public string data_value_38 { get; set; }
        public string data_value_39 { get; set; }
        public string data_value_40 { get; set; }
        public DateTime clm_date_time { get; set; }
        public string clm_user { get; set; }

    }
    public class IOT_DEVICE_EDC_005
    {

        public int id { get; set; }
        public string device_id { get; set; }
        public string data_value_01 { get; set; }
        public string data_value_02 { get; set; }
        public string data_value_03 { get; set; }
        public string data_value_04 { get; set; }
        public string data_value_05 { get; set; }
        public string data_value_06 { get; set; }
        public string data_value_07 { get; set; }
        public string data_value_08 { get; set; }
        public string data_value_09 { get; set; }
        public string data_value_10 { get; set; }
        public string data_value_11 { get; set; }
        public string data_value_12 { get; set; }
        public string data_value_13 { get; set; }
        public string data_value_14 { get; set; }
        public string data_value_15 { get; set; }
        public string data_value_16 { get; set; }
        public string data_value_17 { get; set; }
        public string data_value_18 { get; set; }
        public string data_value_19 { get; set; }
        public string data_value_20 { get; set; }
        public string data_value_21 { get; set; }
        public string data_value_22 { get; set; }
        public string data_value_23 { get; set; }
        public string data_value_24 { get; set; }
        public string data_value_25 { get; set; }
        public string data_value_26 { get; set; }
        public string data_value_27 { get; set; }
        public string data_value_28 { get; set; }
        public string data_value_29 { get; set; }
        public string data_value_30 { get; set; }
        public string data_value_31 { get; set; }
        public string data_value_32 { get; set; }
        public string data_value_33 { get; set; }
        public string data_value_34 { get; set; }
        public string data_value_35 { get; set; }
        public string data_value_36 { get; set; }
        public string data_value_37 { get; set; }
        public string data_value_38 { get; set; }
        public string data_value_39 { get; set; }
        public string data_value_40 { get; set; }
        public DateTime clm_date_time { get; set; }
        public string clm_user { get; set; }

    }
    public class IOT_DEVICE_EDC_006
    {

        public int id { get; set; }
        public string device_id { get; set; }
        public string data_value_01 { get; set; }
        public string data_value_02 { get; set; }
        public string data_value_03 { get; set; }
        public string data_value_04 { get; set; }
        public string data_value_05 { get; set; }
        public string data_value_06 { get; set; }
        public string data_value_07 { get; set; }
        public string data_value_08 { get; set; }
        public string data_value_09 { get; set; }
        public string data_value_10 { get; set; }
        public string data_value_11 { get; set; }
        public string data_value_12 { get; set; }
        public string data_value_13 { get; set; }
        public string data_value_14 { get; set; }
        public string data_value_15 { get; set; }
        public string data_value_16 { get; set; }
        public string data_value_17 { get; set; }
        public string data_value_18 { get; set; }
        public string data_value_19 { get; set; }
        public string data_value_20 { get; set; }
        public string data_value_21 { get; set; }
        public string data_value_22 { get; set; }
        public string data_value_23 { get; set; }
        public string data_value_24 { get; set; }
        public string data_value_25 { get; set; }
        public string data_value_26 { get; set; }
        public string data_value_27 { get; set; }
        public string data_value_28 { get; set; }
        public string data_value_29 { get; set; }
        public string data_value_30 { get; set; }
        public string data_value_31 { get; set; }
        public string data_value_32 { get; set; }
        public string data_value_33 { get; set; }
        public string data_value_34 { get; set; }
        public string data_value_35 { get; set; }
        public string data_value_36 { get; set; }
        public string data_value_37 { get; set; }
        public string data_value_38 { get; set; }
        public string data_value_39 { get; set; }
        public string data_value_40 { get; set; }
        public DateTime clm_date_time { get; set; }
        public string clm_user { get; set; }

    }
    public class IOT_DEVICE_EDC_007
    {

        public int id { get; set; }
        public string device_id { get; set; }
        public string data_value_01 { get; set; }
        public string data_value_02 { get; set; }
        public string data_value_03 { get; set; }
        public string data_value_04 { get; set; }
        public string data_value_05 { get; set; }
        public string data_value_06 { get; set; }
        public string data_value_07 { get; set; }
        public string data_value_08 { get; set; }
        public string data_value_09 { get; set; }
        public string data_value_10 { get; set; }
        public string data_value_11 { get; set; }
        public string data_value_12 { get; set; }
        public string data_value_13 { get; set; }
        public string data_value_14 { get; set; }
        public string data_value_15 { get; set; }
        public string data_value_16 { get; set; }
        public string data_value_17 { get; set; }
        public string data_value_18 { get; set; }
        public string data_value_19 { get; set; }
        public string data_value_20 { get; set; }
        public string data_value_21 { get; set; }
        public string data_value_22 { get; set; }
        public string data_value_23 { get; set; }
        public string data_value_24 { get; set; }
        public string data_value_25 { get; set; }
        public string data_value_26 { get; set; }
        public string data_value_27 { get; set; }
        public string data_value_28 { get; set; }
        public string data_value_29 { get; set; }
        public string data_value_30 { get; set; }
        public string data_value_31 { get; set; }
        public string data_value_32 { get; set; }
        public string data_value_33 { get; set; }
        public string data_value_34 { get; set; }
        public string data_value_35 { get; set; }
        public string data_value_36 { get; set; }
        public string data_value_37 { get; set; }
        public string data_value_38 { get; set; }
        public string data_value_39 { get; set; }
        public string data_value_40 { get; set; }
        public DateTime clm_date_time { get; set; }
        public string clm_user { get; set; }

    }
    public class IOT_DEVICE_EDC_008
    {

        public int id { get; set; }
        public string device_id { get; set; }
        public string data_value_01 { get; set; }
        public string data_value_02 { get; set; }
        public string data_value_03 { get; set; }
        public string data_value_04 { get; set; }
        public string data_value_05 { get; set; }
        public string data_value_06 { get; set; }
        public string data_value_07 { get; set; }
        public string data_value_08 { get; set; }
        public string data_value_09 { get; set; }
        public string data_value_10 { get; set; }
        public string data_value_11 { get; set; }
        public string data_value_12 { get; set; }
        public string data_value_13 { get; set; }
        public string data_value_14 { get; set; }
        public string data_value_15 { get; set; }
        public string data_value_16 { get; set; }
        public string data_value_17 { get; set; }
        public string data_value_18 { get; set; }
        public string data_value_19 { get; set; }
        public string data_value_20 { get; set; }
        public string data_value_21 { get; set; }
        public string data_value_22 { get; set; }
        public string data_value_23 { get; set; }
        public string data_value_24 { get; set; }
        public string data_value_25 { get; set; }
        public string data_value_26 { get; set; }
        public string data_value_27 { get; set; }
        public string data_value_28 { get; set; }
        public string data_value_29 { get; set; }
        public string data_value_30 { get; set; }
        public string data_value_31 { get; set; }
        public string data_value_32 { get; set; }
        public string data_value_33 { get; set; }
        public string data_value_34 { get; set; }
        public string data_value_35 { get; set; }
        public string data_value_36 { get; set; }
        public string data_value_37 { get; set; }
        public string data_value_38 { get; set; }
        public string data_value_39 { get; set; }
        public string data_value_40 { get; set; }
        public DateTime clm_date_time { get; set; }
        public string clm_user { get; set; }

    }
    public class IOT_DEVICE_EDC_009
    {

        public int id { get; set; }
        public string device_id { get; set; }
        public string data_value_01 { get; set; }
        public string data_value_02 { get; set; }
        public string data_value_03 { get; set; }
        public string data_value_04 { get; set; }
        public string data_value_05 { get; set; }
        public string data_value_06 { get; set; }
        public string data_value_07 { get; set; }
        public string data_value_08 { get; set; }
        public string data_value_09 { get; set; }
        public string data_value_10 { get; set; }
        public string data_value_11 { get; set; }
        public string data_value_12 { get; set; }
        public string data_value_13 { get; set; }
        public string data_value_14 { get; set; }
        public string data_value_15 { get; set; }
        public string data_value_16 { get; set; }
        public string data_value_17 { get; set; }
        public string data_value_18 { get; set; }
        public string data_value_19 { get; set; }
        public string data_value_20 { get; set; }
        public string data_value_21 { get; set; }
        public string data_value_22 { get; set; }
        public string data_value_23 { get; set; }
        public string data_value_24 { get; set; }
        public string data_value_25 { get; set; }
        public string data_value_26 { get; set; }
        public string data_value_27 { get; set; }
        public string data_value_28 { get; set; }
        public string data_value_29 { get; set; }
        public string data_value_30 { get; set; }
        public string data_value_31 { get; set; }
        public string data_value_32 { get; set; }
        public string data_value_33 { get; set; }
        public string data_value_34 { get; set; }
        public string data_value_35 { get; set; }
        public string data_value_36 { get; set; }
        public string data_value_37 { get; set; }
        public string data_value_38 { get; set; }
        public string data_value_39 { get; set; }
        public string data_value_40 { get; set; }
        public DateTime clm_date_time { get; set; }
        public string clm_user { get; set; }

    }
    public class IOT_DEVICE_EDC_010
    {

        public int id { get; set; }
        public string device_id { get; set; }
        public string data_value_01 { get; set; }
        public string data_value_02 { get; set; }
        public string data_value_03 { get; set; }
        public string data_value_04 { get; set; }
        public string data_value_05 { get; set; }
        public string data_value_06 { get; set; }
        public string data_value_07 { get; set; }
        public string data_value_08 { get; set; }
        public string data_value_09 { get; set; }
        public string data_value_10 { get; set; }
        public string data_value_11 { get; set; }
        public string data_value_12 { get; set; }
        public string data_value_13 { get; set; }
        public string data_value_14 { get; set; }
        public string data_value_15 { get; set; }
        public string data_value_16 { get; set; }
        public string data_value_17 { get; set; }
        public string data_value_18 { get; set; }
        public string data_value_19 { get; set; }
        public string data_value_20 { get; set; }
        public string data_value_21 { get; set; }
        public string data_value_22 { get; set; }
        public string data_value_23 { get; set; }
        public string data_value_24 { get; set; }
        public string data_value_25 { get; set; }
        public string data_value_26 { get; set; }
        public string data_value_27 { get; set; }
        public string data_value_28 { get; set; }
        public string data_value_29 { get; set; }
        public string data_value_30 { get; set; }
        public string data_value_31 { get; set; }
        public string data_value_32 { get; set; }
        public string data_value_33 { get; set; }
        public string data_value_34 { get; set; }
        public string data_value_35 { get; set; }
        public string data_value_36 { get; set; }
        public string data_value_37 { get; set; }
        public string data_value_38 { get; set; }
        public string data_value_39 { get; set; }
        public string data_value_40 { get; set; }
        public DateTime clm_date_time { get; set; }
        public string clm_user { get; set; }

    }
    public class IOT_DEVICE_EDC_011
    {

        public int id { get; set; }
        public string device_id { get; set; }
        public string data_value_01 { get; set; }
        public string data_value_02 { get; set; }
        public string data_value_03 { get; set; }
        public string data_value_04 { get; set; }
        public string data_value_05 { get; set; }
        public string data_value_06 { get; set; }
        public string data_value_07 { get; set; }
        public string data_value_08 { get; set; }
        public string data_value_09 { get; set; }
        public string data_value_10 { get; set; }
        public string data_value_11 { get; set; }
        public string data_value_12 { get; set; }
        public string data_value_13 { get; set; }
        public string data_value_14 { get; set; }
        public string data_value_15 { get; set; }
        public string data_value_16 { get; set; }
        public string data_value_17 { get; set; }
        public string data_value_18 { get; set; }
        public string data_value_19 { get; set; }
        public string data_value_20 { get; set; }
        public string data_value_21 { get; set; }
        public string data_value_22 { get; set; }
        public string data_value_23 { get; set; }
        public string data_value_24 { get; set; }
        public string data_value_25 { get; set; }
        public string data_value_26 { get; set; }
        public string data_value_27 { get; set; }
        public string data_value_28 { get; set; }
        public string data_value_29 { get; set; }
        public string data_value_30 { get; set; }
        public string data_value_31 { get; set; }
        public string data_value_32 { get; set; }
        public string data_value_33 { get; set; }
        public string data_value_34 { get; set; }
        public string data_value_35 { get; set; }
        public string data_value_36 { get; set; }
        public string data_value_37 { get; set; }
        public string data_value_38 { get; set; }
        public string data_value_39 { get; set; }
        public string data_value_40 { get; set; }
        public DateTime clm_date_time { get; set; }
        public string clm_user { get; set; }

    }
    public class IOT_DEVICE_EDC_012
    {

        public int id { get; set; }
        public string device_id { get; set; }
        public string data_value_01 { get; set; }
        public string data_value_02 { get; set; }
        public string data_value_03 { get; set; }
        public string data_value_04 { get; set; }
        public string data_value_05 { get; set; }
        public string data_value_06 { get; set; }
        public string data_value_07 { get; set; }
        public string data_value_08 { get; set; }
        public string data_value_09 { get; set; }
        public string data_value_10 { get; set; }
        public string data_value_11 { get; set; }
        public string data_value_12 { get; set; }
        public string data_value_13 { get; set; }
        public string data_value_14 { get; set; }
        public string data_value_15 { get; set; }
        public string data_value_16 { get; set; }
        public string data_value_17 { get; set; }
        public string data_value_18 { get; set; }
        public string data_value_19 { get; set; }
        public string data_value_20 { get; set; }
        public string data_value_21 { get; set; }
        public string data_value_22 { get; set; }
        public string data_value_23 { get; set; }
        public string data_value_24 { get; set; }
        public string data_value_25 { get; set; }
        public string data_value_26 { get; set; }
        public string data_value_27 { get; set; }
        public string data_value_28 { get; set; }
        public string data_value_29 { get; set; }
        public string data_value_30 { get; set; }
        public string data_value_31 { get; set; }
        public string data_value_32 { get; set; }
        public string data_value_33 { get; set; }
        public string data_value_34 { get; set; }
        public string data_value_35 { get; set; }
        public string data_value_36 { get; set; }
        public string data_value_37 { get; set; }
        public string data_value_38 { get; set; }
        public string data_value_39 { get; set; }
        public string data_value_40 { get; set; }
        public DateTime clm_date_time { get; set; }
        public string clm_user { get; set; }

    }
    public class IOT_DEVICE_EDC_013
    {

        public int id { get; set; }
        public string device_id { get; set; }
        public string data_value_01 { get; set; }
        public string data_value_02 { get; set; }
        public string data_value_03 { get; set; }
        public string data_value_04 { get; set; }
        public string data_value_05 { get; set; }
        public string data_value_06 { get; set; }
        public string data_value_07 { get; set; }
        public string data_value_08 { get; set; }
        public string data_value_09 { get; set; }
        public string data_value_10 { get; set; }
        public string data_value_11 { get; set; }
        public string data_value_12 { get; set; }
        public string data_value_13 { get; set; }
        public string data_value_14 { get; set; }
        public string data_value_15 { get; set; }
        public string data_value_16 { get; set; }
        public string data_value_17 { get; set; }
        public string data_value_18 { get; set; }
        public string data_value_19 { get; set; }
        public string data_value_20 { get; set; }
        public string data_value_21 { get; set; }
        public string data_value_22 { get; set; }
        public string data_value_23 { get; set; }
        public string data_value_24 { get; set; }
        public string data_value_25 { get; set; }
        public string data_value_26 { get; set; }
        public string data_value_27 { get; set; }
        public string data_value_28 { get; set; }
        public string data_value_29 { get; set; }
        public string data_value_30 { get; set; }
        public string data_value_31 { get; set; }
        public string data_value_32 { get; set; }
        public string data_value_33 { get; set; }
        public string data_value_34 { get; set; }
        public string data_value_35 { get; set; }
        public string data_value_36 { get; set; }
        public string data_value_37 { get; set; }
        public string data_value_38 { get; set; }
        public string data_value_39 { get; set; }
        public string data_value_40 { get; set; }
        public DateTime clm_date_time { get; set; }
        public string clm_user { get; set; }

    }
    public class IOT_DEVICE_EDC_014
    {

        public int id { get; set; }
        public string device_id { get; set; }
        public string data_value_01 { get; set; }
        public string data_value_02 { get; set; }
        public string data_value_03 { get; set; }
        public string data_value_04 { get; set; }
        public string data_value_05 { get; set; }
        public string data_value_06 { get; set; }
        public string data_value_07 { get; set; }
        public string data_value_08 { get; set; }
        public string data_value_09 { get; set; }
        public string data_value_10 { get; set; }
        public string data_value_11 { get; set; }
        public string data_value_12 { get; set; }
        public string data_value_13 { get; set; }
        public string data_value_14 { get; set; }
        public string data_value_15 { get; set; }
        public string data_value_16 { get; set; }
        public string data_value_17 { get; set; }
        public string data_value_18 { get; set; }
        public string data_value_19 { get; set; }
        public string data_value_20 { get; set; }
        public string data_value_21 { get; set; }
        public string data_value_22 { get; set; }
        public string data_value_23 { get; set; }
        public string data_value_24 { get; set; }
        public string data_value_25 { get; set; }
        public string data_value_26 { get; set; }
        public string data_value_27 { get; set; }
        public string data_value_28 { get; set; }
        public string data_value_29 { get; set; }
        public string data_value_30 { get; set; }
        public string data_value_31 { get; set; }
        public string data_value_32 { get; set; }
        public string data_value_33 { get; set; }
        public string data_value_34 { get; set; }
        public string data_value_35 { get; set; }
        public string data_value_36 { get; set; }
        public string data_value_37 { get; set; }
        public string data_value_38 { get; set; }
        public string data_value_39 { get; set; }
        public string data_value_40 { get; set; }
        public DateTime clm_date_time { get; set; }
        public string clm_user { get; set; }

    }
    public class IOT_DEVICE_EDC_015
    {

        public int id { get; set; }
        public string device_id { get; set; }
        public string data_value_01 { get; set; }
        public string data_value_02 { get; set; }
        public string data_value_03 { get; set; }
        public string data_value_04 { get; set; }
        public string data_value_05 { get; set; }
        public string data_value_06 { get; set; }
        public string data_value_07 { get; set; }
        public string data_value_08 { get; set; }
        public string data_value_09 { get; set; }
        public string data_value_10 { get; set; }
        public string data_value_11 { get; set; }
        public string data_value_12 { get; set; }
        public string data_value_13 { get; set; }
        public string data_value_14 { get; set; }
        public string data_value_15 { get; set; }
        public string data_value_16 { get; set; }
        public string data_value_17 { get; set; }
        public string data_value_18 { get; set; }
        public string data_value_19 { get; set; }
        public string data_value_20 { get; set; }
        public string data_value_21 { get; set; }
        public string data_value_22 { get; set; }
        public string data_value_23 { get; set; }
        public string data_value_24 { get; set; }
        public string data_value_25 { get; set; }
        public string data_value_26 { get; set; }
        public string data_value_27 { get; set; }
        public string data_value_28 { get; set; }
        public string data_value_29 { get; set; }
        public string data_value_30 { get; set; }
        public string data_value_31 { get; set; }
        public string data_value_32 { get; set; }
        public string data_value_33 { get; set; }
        public string data_value_34 { get; set; }
        public string data_value_35 { get; set; }
        public string data_value_36 { get; set; }
        public string data_value_37 { get; set; }
        public string data_value_38 { get; set; }
        public string data_value_39 { get; set; }
        public string data_value_40 { get; set; }
        public DateTime clm_date_time { get; set; }
        public string clm_user { get; set; }

    }
    public class IOT_DEVICE_EDC_016
    {

        public int id { get; set; }
        public string device_id { get; set; }
        public string data_value_01 { get; set; }
        public string data_value_02 { get; set; }
        public string data_value_03 { get; set; }
        public string data_value_04 { get; set; }
        public string data_value_05 { get; set; }
        public string data_value_06 { get; set; }
        public string data_value_07 { get; set; }
        public string data_value_08 { get; set; }
        public string data_value_09 { get; set; }
        public string data_value_10 { get; set; }
        public string data_value_11 { get; set; }
        public string data_value_12 { get; set; }
        public string data_value_13 { get; set; }
        public string data_value_14 { get; set; }
        public string data_value_15 { get; set; }
        public string data_value_16 { get; set; }
        public string data_value_17 { get; set; }
        public string data_value_18 { get; set; }
        public string data_value_19 { get; set; }
        public string data_value_20 { get; set; }
        public string data_value_21 { get; set; }
        public string data_value_22 { get; set; }
        public string data_value_23 { get; set; }
        public string data_value_24 { get; set; }
        public string data_value_25 { get; set; }
        public string data_value_26 { get; set; }
        public string data_value_27 { get; set; }
        public string data_value_28 { get; set; }
        public string data_value_29 { get; set; }
        public string data_value_30 { get; set; }
        public string data_value_31 { get; set; }
        public string data_value_32 { get; set; }
        public string data_value_33 { get; set; }
        public string data_value_34 { get; set; }
        public string data_value_35 { get; set; }
        public string data_value_36 { get; set; }
        public string data_value_37 { get; set; }
        public string data_value_38 { get; set; }
        public string data_value_39 { get; set; }
        public string data_value_40 { get; set; }
        public DateTime clm_date_time { get; set; }
        public string clm_user { get; set; }

    }
    public class IOT_DEVICE_EDC_017
    {

        public int id { get; set; }
        public string device_id { get; set; }
        public string data_value_01 { get; set; }
        public string data_value_02 { get; set; }
        public string data_value_03 { get; set; }
        public string data_value_04 { get; set; }
        public string data_value_05 { get; set; }
        public string data_value_06 { get; set; }
        public string data_value_07 { get; set; }
        public string data_value_08 { get; set; }
        public string data_value_09 { get; set; }
        public string data_value_10 { get; set; }
        public string data_value_11 { get; set; }
        public string data_value_12 { get; set; }
        public string data_value_13 { get; set; }
        public string data_value_14 { get; set; }
        public string data_value_15 { get; set; }
        public string data_value_16 { get; set; }
        public string data_value_17 { get; set; }
        public string data_value_18 { get; set; }
        public string data_value_19 { get; set; }
        public string data_value_20 { get; set; }
        public string data_value_21 { get; set; }
        public string data_value_22 { get; set; }
        public string data_value_23 { get; set; }
        public string data_value_24 { get; set; }
        public string data_value_25 { get; set; }
        public string data_value_26 { get; set; }
        public string data_value_27 { get; set; }
        public string data_value_28 { get; set; }
        public string data_value_29 { get; set; }
        public string data_value_30 { get; set; }
        public string data_value_31 { get; set; }
        public string data_value_32 { get; set; }
        public string data_value_33 { get; set; }
        public string data_value_34 { get; set; }
        public string data_value_35 { get; set; }
        public string data_value_36 { get; set; }
        public string data_value_37 { get; set; }
        public string data_value_38 { get; set; }
        public string data_value_39 { get; set; }
        public string data_value_40 { get; set; }
        public DateTime clm_date_time { get; set; }
        public string clm_user { get; set; }

    }
    public class IOT_DEVICE_EDC_018
    {

        public int id { get; set; }
        public string device_id { get; set; }
        public string data_value_01 { get; set; }
        public string data_value_02 { get; set; }
        public string data_value_03 { get; set; }
        public string data_value_04 { get; set; }
        public string data_value_05 { get; set; }
        public string data_value_06 { get; set; }
        public string data_value_07 { get; set; }
        public string data_value_08 { get; set; }
        public string data_value_09 { get; set; }
        public string data_value_10 { get; set; }
        public string data_value_11 { get; set; }
        public string data_value_12 { get; set; }
        public string data_value_13 { get; set; }
        public string data_value_14 { get; set; }
        public string data_value_15 { get; set; }
        public string data_value_16 { get; set; }
        public string data_value_17 { get; set; }
        public string data_value_18 { get; set; }
        public string data_value_19 { get; set; }
        public string data_value_20 { get; set; }
        public string data_value_21 { get; set; }
        public string data_value_22 { get; set; }
        public string data_value_23 { get; set; }
        public string data_value_24 { get; set; }
        public string data_value_25 { get; set; }
        public string data_value_26 { get; set; }
        public string data_value_27 { get; set; }
        public string data_value_28 { get; set; }
        public string data_value_29 { get; set; }
        public string data_value_30 { get; set; }
        public string data_value_31 { get; set; }
        public string data_value_32 { get; set; }
        public string data_value_33 { get; set; }
        public string data_value_34 { get; set; }
        public string data_value_35 { get; set; }
        public string data_value_36 { get; set; }
        public string data_value_37 { get; set; }
        public string data_value_38 { get; set; }
        public string data_value_39 { get; set; }
        public string data_value_40 { get; set; }
        public DateTime clm_date_time { get; set; }
        public string clm_user { get; set; }

    }
    public class IOT_DEVICE_EDC_019
    {

        public int id { get; set; }
        public string device_id { get; set; }
        public string data_value_01 { get; set; }
        public string data_value_02 { get; set; }
        public string data_value_03 { get; set; }
        public string data_value_04 { get; set; }
        public string data_value_05 { get; set; }
        public string data_value_06 { get; set; }
        public string data_value_07 { get; set; }
        public string data_value_08 { get; set; }
        public string data_value_09 { get; set; }
        public string data_value_10 { get; set; }
        public string data_value_11 { get; set; }
        public string data_value_12 { get; set; }
        public string data_value_13 { get; set; }
        public string data_value_14 { get; set; }
        public string data_value_15 { get; set; }
        public string data_value_16 { get; set; }
        public string data_value_17 { get; set; }
        public string data_value_18 { get; set; }
        public string data_value_19 { get; set; }
        public string data_value_20 { get; set; }
        public string data_value_21 { get; set; }
        public string data_value_22 { get; set; }
        public string data_value_23 { get; set; }
        public string data_value_24 { get; set; }
        public string data_value_25 { get; set; }
        public string data_value_26 { get; set; }
        public string data_value_27 { get; set; }
        public string data_value_28 { get; set; }
        public string data_value_29 { get; set; }
        public string data_value_30 { get; set; }
        public string data_value_31 { get; set; }
        public string data_value_32 { get; set; }
        public string data_value_33 { get; set; }
        public string data_value_34 { get; set; }
        public string data_value_35 { get; set; }
        public string data_value_36 { get; set; }
        public string data_value_37 { get; set; }
        public string data_value_38 { get; set; }
        public string data_value_39 { get; set; }
        public string data_value_40 { get; set; }
        public DateTime clm_date_time { get; set; }
        public string clm_user { get; set; }

    }
    public class IOT_DEVICE_EDC_020
    {

        public int id { get; set; }
        public string device_id { get; set; }
        public string data_value_01 { get; set; }
        public string data_value_02 { get; set; }
        public string data_value_03 { get; set; }
        public string data_value_04 { get; set; }
        public string data_value_05 { get; set; }
        public string data_value_06 { get; set; }
        public string data_value_07 { get; set; }
        public string data_value_08 { get; set; }
        public string data_value_09 { get; set; }
        public string data_value_10 { get; set; }
        public string data_value_11 { get; set; }
        public string data_value_12 { get; set; }
        public string data_value_13 { get; set; }
        public string data_value_14 { get; set; }
        public string data_value_15 { get; set; }
        public string data_value_16 { get; set; }
        public string data_value_17 { get; set; }
        public string data_value_18 { get; set; }
        public string data_value_19 { get; set; }
        public string data_value_20 { get; set; }
        public string data_value_21 { get; set; }
        public string data_value_22 { get; set; }
        public string data_value_23 { get; set; }
        public string data_value_24 { get; set; }
        public string data_value_25 { get; set; }
        public string data_value_26 { get; set; }
        public string data_value_27 { get; set; }
        public string data_value_28 { get; set; }
        public string data_value_29 { get; set; }
        public string data_value_30 { get; set; }
        public string data_value_31 { get; set; }
        public string data_value_32 { get; set; }
        public string data_value_33 { get; set; }
        public string data_value_34 { get; set; }
        public string data_value_35 { get; set; }
        public string data_value_36 { get; set; }
        public string data_value_37 { get; set; }
        public string data_value_38 { get; set; }
        public string data_value_39 { get; set; }
        public string data_value_40 { get; set; }
        public DateTime clm_date_time { get; set; }
        public string clm_user { get; set; }

    }
    public class IOT_DEVICE_EDC_021
    {

        public int id { get; set; }
        public string device_id { get; set; }
        public string data_value_01 { get; set; }
        public string data_value_02 { get; set; }
        public string data_value_03 { get; set; }
        public string data_value_04 { get; set; }
        public string data_value_05 { get; set; }
        public string data_value_06 { get; set; }
        public string data_value_07 { get; set; }
        public string data_value_08 { get; set; }
        public string data_value_09 { get; set; }
        public string data_value_10 { get; set; }
        public string data_value_11 { get; set; }
        public string data_value_12 { get; set; }
        public string data_value_13 { get; set; }
        public string data_value_14 { get; set; }
        public string data_value_15 { get; set; }
        public string data_value_16 { get; set; }
        public string data_value_17 { get; set; }
        public string data_value_18 { get; set; }
        public string data_value_19 { get; set; }
        public string data_value_20 { get; set; }
        public string data_value_21 { get; set; }
        public string data_value_22 { get; set; }
        public string data_value_23 { get; set; }
        public string data_value_24 { get; set; }
        public string data_value_25 { get; set; }
        public string data_value_26 { get; set; }
        public string data_value_27 { get; set; }
        public string data_value_28 { get; set; }
        public string data_value_29 { get; set; }
        public string data_value_30 { get; set; }
        public string data_value_31 { get; set; }
        public string data_value_32 { get; set; }
        public string data_value_33 { get; set; }
        public string data_value_34 { get; set; }
        public string data_value_35 { get; set; }
        public string data_value_36 { get; set; }
        public string data_value_37 { get; set; }
        public string data_value_38 { get; set; }
        public string data_value_39 { get; set; }
        public string data_value_40 { get; set; }
        public DateTime clm_date_time { get; set; }
        public string clm_user { get; set; }

    }
    public class IOT_DEVICE_EDC_022
    {

        public int id { get; set; }
        public string device_id { get; set; }
        public string data_value_01 { get; set; }
        public string data_value_02 { get; set; }
        public string data_value_03 { get; set; }
        public string data_value_04 { get; set; }
        public string data_value_05 { get; set; }
        public string data_value_06 { get; set; }
        public string data_value_07 { get; set; }
        public string data_value_08 { get; set; }
        public string data_value_09 { get; set; }
        public string data_value_10 { get; set; }
        public string data_value_11 { get; set; }
        public string data_value_12 { get; set; }
        public string data_value_13 { get; set; }
        public string data_value_14 { get; set; }
        public string data_value_15 { get; set; }
        public string data_value_16 { get; set; }
        public string data_value_17 { get; set; }
        public string data_value_18 { get; set; }
        public string data_value_19 { get; set; }
        public string data_value_20 { get; set; }
        public string data_value_21 { get; set; }
        public string data_value_22 { get; set; }
        public string data_value_23 { get; set; }
        public string data_value_24 { get; set; }
        public string data_value_25 { get; set; }
        public string data_value_26 { get; set; }
        public string data_value_27 { get; set; }
        public string data_value_28 { get; set; }
        public string data_value_29 { get; set; }
        public string data_value_30 { get; set; }
        public string data_value_31 { get; set; }
        public string data_value_32 { get; set; }
        public string data_value_33 { get; set; }
        public string data_value_34 { get; set; }
        public string data_value_35 { get; set; }
        public string data_value_36 { get; set; }
        public string data_value_37 { get; set; }
        public string data_value_38 { get; set; }
        public string data_value_39 { get; set; }
        public string data_value_40 { get; set; }
        public DateTime clm_date_time { get; set; }
        public string clm_user { get; set; }

    }
    public class IOT_DEVICE_EDC_023
    {

        public int id { get; set; }
        public string device_id { get; set; }
        public string data_value_01 { get; set; }
        public string data_value_02 { get; set; }
        public string data_value_03 { get; set; }
        public string data_value_04 { get; set; }
        public string data_value_05 { get; set; }
        public string data_value_06 { get; set; }
        public string data_value_07 { get; set; }
        public string data_value_08 { get; set; }
        public string data_value_09 { get; set; }
        public string data_value_10 { get; set; }
        public string data_value_11 { get; set; }
        public string data_value_12 { get; set; }
        public string data_value_13 { get; set; }
        public string data_value_14 { get; set; }
        public string data_value_15 { get; set; }
        public string data_value_16 { get; set; }
        public string data_value_17 { get; set; }
        public string data_value_18 { get; set; }
        public string data_value_19 { get; set; }
        public string data_value_20 { get; set; }
        public string data_value_21 { get; set; }
        public string data_value_22 { get; set; }
        public string data_value_23 { get; set; }
        public string data_value_24 { get; set; }
        public string data_value_25 { get; set; }
        public string data_value_26 { get; set; }
        public string data_value_27 { get; set; }
        public string data_value_28 { get; set; }
        public string data_value_29 { get; set; }
        public string data_value_30 { get; set; }
        public string data_value_31 { get; set; }
        public string data_value_32 { get; set; }
        public string data_value_33 { get; set; }
        public string data_value_34 { get; set; }
        public string data_value_35 { get; set; }
        public string data_value_36 { get; set; }
        public string data_value_37 { get; set; }
        public string data_value_38 { get; set; }
        public string data_value_39 { get; set; }
        public string data_value_40 { get; set; }
        public DateTime clm_date_time { get; set; }
        public string clm_user { get; set; }

    }
    public class IOT_DEVICE_EDC_024
    {

        public int id { get; set; }
        public string device_id { get; set; }
        public string data_value_01 { get; set; }
        public string data_value_02 { get; set; }
        public string data_value_03 { get; set; }
        public string data_value_04 { get; set; }
        public string data_value_05 { get; set; }
        public string data_value_06 { get; set; }
        public string data_value_07 { get; set; }
        public string data_value_08 { get; set; }
        public string data_value_09 { get; set; }
        public string data_value_10 { get; set; }
        public string data_value_11 { get; set; }
        public string data_value_12 { get; set; }
        public string data_value_13 { get; set; }
        public string data_value_14 { get; set; }
        public string data_value_15 { get; set; }
        public string data_value_16 { get; set; }
        public string data_value_17 { get; set; }
        public string data_value_18 { get; set; }
        public string data_value_19 { get; set; }
        public string data_value_20 { get; set; }
        public string data_value_21 { get; set; }
        public string data_value_22 { get; set; }
        public string data_value_23 { get; set; }
        public string data_value_24 { get; set; }
        public string data_value_25 { get; set; }
        public string data_value_26 { get; set; }
        public string data_value_27 { get; set; }
        public string data_value_28 { get; set; }
        public string data_value_29 { get; set; }
        public string data_value_30 { get; set; }
        public string data_value_31 { get; set; }
        public string data_value_32 { get; set; }
        public string data_value_33 { get; set; }
        public string data_value_34 { get; set; }
        public string data_value_35 { get; set; }
        public string data_value_36 { get; set; }
        public string data_value_37 { get; set; }
        public string data_value_38 { get; set; }
        public string data_value_39 { get; set; }
        public string data_value_40 { get; set; }
        public DateTime clm_date_time { get; set; }
        public string clm_user { get; set; }

    }
    public class IOT_DEVICE_EDC_025
    {

        public int id { get; set; }
        public string device_id { get; set; }
        public string data_value_01 { get; set; }
        public string data_value_02 { get; set; }
        public string data_value_03 { get; set; }
        public string data_value_04 { get; set; }
        public string data_value_05 { get; set; }
        public string data_value_06 { get; set; }
        public string data_value_07 { get; set; }
        public string data_value_08 { get; set; }
        public string data_value_09 { get; set; }
        public string data_value_10 { get; set; }
        public string data_value_11 { get; set; }
        public string data_value_12 { get; set; }
        public string data_value_13 { get; set; }
        public string data_value_14 { get; set; }
        public string data_value_15 { get; set; }
        public string data_value_16 { get; set; }
        public string data_value_17 { get; set; }
        public string data_value_18 { get; set; }
        public string data_value_19 { get; set; }
        public string data_value_20 { get; set; }
        public string data_value_21 { get; set; }
        public string data_value_22 { get; set; }
        public string data_value_23 { get; set; }
        public string data_value_24 { get; set; }
        public string data_value_25 { get; set; }
        public string data_value_26 { get; set; }
        public string data_value_27 { get; set; }
        public string data_value_28 { get; set; }
        public string data_value_29 { get; set; }
        public string data_value_30 { get; set; }
        public string data_value_31 { get; set; }
        public string data_value_32 { get; set; }
        public string data_value_33 { get; set; }
        public string data_value_34 { get; set; }
        public string data_value_35 { get; set; }
        public string data_value_36 { get; set; }
        public string data_value_37 { get; set; }
        public string data_value_38 { get; set; }
        public string data_value_39 { get; set; }
        public string data_value_40 { get; set; }
        public DateTime clm_date_time { get; set; }
        public string clm_user { get; set; }

    }
    public class IOT_DEVICE_EDC_026
    {

        public int id { get; set; }
        public string device_id { get; set; }
        public string data_value_01 { get; set; }
        public string data_value_02 { get; set; }
        public string data_value_03 { get; set; }
        public string data_value_04 { get; set; }
        public string data_value_05 { get; set; }
        public string data_value_06 { get; set; }
        public string data_value_07 { get; set; }
        public string data_value_08 { get; set; }
        public string data_value_09 { get; set; }
        public string data_value_10 { get; set; }
        public string data_value_11 { get; set; }
        public string data_value_12 { get; set; }
        public string data_value_13 { get; set; }
        public string data_value_14 { get; set; }
        public string data_value_15 { get; set; }
        public string data_value_16 { get; set; }
        public string data_value_17 { get; set; }
        public string data_value_18 { get; set; }
        public string data_value_19 { get; set; }
        public string data_value_20 { get; set; }
        public string data_value_21 { get; set; }
        public string data_value_22 { get; set; }
        public string data_value_23 { get; set; }
        public string data_value_24 { get; set; }
        public string data_value_25 { get; set; }
        public string data_value_26 { get; set; }
        public string data_value_27 { get; set; }
        public string data_value_28 { get; set; }
        public string data_value_29 { get; set; }
        public string data_value_30 { get; set; }
        public string data_value_31 { get; set; }
        public string data_value_32 { get; set; }
        public string data_value_33 { get; set; }
        public string data_value_34 { get; set; }
        public string data_value_35 { get; set; }
        public string data_value_36 { get; set; }
        public string data_value_37 { get; set; }
        public string data_value_38 { get; set; }
        public string data_value_39 { get; set; }
        public string data_value_40 { get; set; }
        public DateTime clm_date_time { get; set; }
        public string clm_user { get; set; }

    }
    public class IOT_DEVICE_EDC_027
    {

        public int id { get; set; }
        public string device_id { get; set; }
        public string data_value_01 { get; set; }
        public string data_value_02 { get; set; }
        public string data_value_03 { get; set; }
        public string data_value_04 { get; set; }
        public string data_value_05 { get; set; }
        public string data_value_06 { get; set; }
        public string data_value_07 { get; set; }
        public string data_value_08 { get; set; }
        public string data_value_09 { get; set; }
        public string data_value_10 { get; set; }
        public string data_value_11 { get; set; }
        public string data_value_12 { get; set; }
        public string data_value_13 { get; set; }
        public string data_value_14 { get; set; }
        public string data_value_15 { get; set; }
        public string data_value_16 { get; set; }
        public string data_value_17 { get; set; }
        public string data_value_18 { get; set; }
        public string data_value_19 { get; set; }
        public string data_value_20 { get; set; }
        public string data_value_21 { get; set; }
        public string data_value_22 { get; set; }
        public string data_value_23 { get; set; }
        public string data_value_24 { get; set; }
        public string data_value_25 { get; set; }
        public string data_value_26 { get; set; }
        public string data_value_27 { get; set; }
        public string data_value_28 { get; set; }
        public string data_value_29 { get; set; }
        public string data_value_30 { get; set; }
        public string data_value_31 { get; set; }
        public string data_value_32 { get; set; }
        public string data_value_33 { get; set; }
        public string data_value_34 { get; set; }
        public string data_value_35 { get; set; }
        public string data_value_36 { get; set; }
        public string data_value_37 { get; set; }
        public string data_value_38 { get; set; }
        public string data_value_39 { get; set; }
        public string data_value_40 { get; set; }
        public DateTime clm_date_time { get; set; }
        public string clm_user { get; set; }

    }
    public class IOT_DEVICE_EDC_028
    {

        public int id { get; set; }
        public string device_id { get; set; }
        public string data_value_01 { get; set; }
        public string data_value_02 { get; set; }
        public string data_value_03 { get; set; }
        public string data_value_04 { get; set; }
        public string data_value_05 { get; set; }
        public string data_value_06 { get; set; }
        public string data_value_07 { get; set; }
        public string data_value_08 { get; set; }
        public string data_value_09 { get; set; }
        public string data_value_10 { get; set; }
        public string data_value_11 { get; set; }
        public string data_value_12 { get; set; }
        public string data_value_13 { get; set; }
        public string data_value_14 { get; set; }
        public string data_value_15 { get; set; }
        public string data_value_16 { get; set; }
        public string data_value_17 { get; set; }
        public string data_value_18 { get; set; }
        public string data_value_19 { get; set; }
        public string data_value_20 { get; set; }
        public string data_value_21 { get; set; }
        public string data_value_22 { get; set; }
        public string data_value_23 { get; set; }
        public string data_value_24 { get; set; }
        public string data_value_25 { get; set; }
        public string data_value_26 { get; set; }
        public string data_value_27 { get; set; }
        public string data_value_28 { get; set; }
        public string data_value_29 { get; set; }
        public string data_value_30 { get; set; }
        public string data_value_31 { get; set; }
        public string data_value_32 { get; set; }
        public string data_value_33 { get; set; }
        public string data_value_34 { get; set; }
        public string data_value_35 { get; set; }
        public string data_value_36 { get; set; }
        public string data_value_37 { get; set; }
        public string data_value_38 { get; set; }
        public string data_value_39 { get; set; }
        public string data_value_40 { get; set; }
        public DateTime clm_date_time { get; set; }
        public string clm_user { get; set; }

    }
    public class IOT_DEVICE_EDC_029
    {

        public int id { get; set; }
        public string device_id { get; set; }
        public string data_value_01 { get; set; }
        public string data_value_02 { get; set; }
        public string data_value_03 { get; set; }
        public string data_value_04 { get; set; }
        public string data_value_05 { get; set; }
        public string data_value_06 { get; set; }
        public string data_value_07 { get; set; }
        public string data_value_08 { get; set; }
        public string data_value_09 { get; set; }
        public string data_value_10 { get; set; }
        public string data_value_11 { get; set; }
        public string data_value_12 { get; set; }
        public string data_value_13 { get; set; }
        public string data_value_14 { get; set; }
        public string data_value_15 { get; set; }
        public string data_value_16 { get; set; }
        public string data_value_17 { get; set; }
        public string data_value_18 { get; set; }
        public string data_value_19 { get; set; }
        public string data_value_20 { get; set; }
        public string data_value_21 { get; set; }
        public string data_value_22 { get; set; }
        public string data_value_23 { get; set; }
        public string data_value_24 { get; set; }
        public string data_value_25 { get; set; }
        public string data_value_26 { get; set; }
        public string data_value_27 { get; set; }
        public string data_value_28 { get; set; }
        public string data_value_29 { get; set; }
        public string data_value_30 { get; set; }
        public string data_value_31 { get; set; }
        public string data_value_32 { get; set; }
        public string data_value_33 { get; set; }
        public string data_value_34 { get; set; }
        public string data_value_35 { get; set; }
        public string data_value_36 { get; set; }
        public string data_value_37 { get; set; }
        public string data_value_38 { get; set; }
        public string data_value_39 { get; set; }
        public string data_value_40 { get; set; }
        public DateTime clm_date_time { get; set; }
        public string clm_user { get; set; }

    }
    public class IOT_DEVICE_EDC_030
    {

        public int id { get; set; }
        public string device_id { get; set; }
        public string data_value_01 { get; set; }
        public string data_value_02 { get; set; }
        public string data_value_03 { get; set; }
        public string data_value_04 { get; set; }
        public string data_value_05 { get; set; }
        public string data_value_06 { get; set; }
        public string data_value_07 { get; set; }
        public string data_value_08 { get; set; }
        public string data_value_09 { get; set; }
        public string data_value_10 { get; set; }
        public string data_value_11 { get; set; }
        public string data_value_12 { get; set; }
        public string data_value_13 { get; set; }
        public string data_value_14 { get; set; }
        public string data_value_15 { get; set; }
        public string data_value_16 { get; set; }
        public string data_value_17 { get; set; }
        public string data_value_18 { get; set; }
        public string data_value_19 { get; set; }
        public string data_value_20 { get; set; }
        public string data_value_21 { get; set; }
        public string data_value_22 { get; set; }
        public string data_value_23 { get; set; }
        public string data_value_24 { get; set; }
        public string data_value_25 { get; set; }
        public string data_value_26 { get; set; }
        public string data_value_27 { get; set; }
        public string data_value_28 { get; set; }
        public string data_value_29 { get; set; }
        public string data_value_30 { get; set; }
        public string data_value_31 { get; set; }
        public string data_value_32 { get; set; }
        public string data_value_33 { get; set; }
        public string data_value_34 { get; set; }
        public string data_value_35 { get; set; }
        public string data_value_36 { get; set; }
        public string data_value_37 { get; set; }
        public string data_value_38 { get; set; }
        public string data_value_39 { get; set; }
        public string data_value_40 { get; set; }
        public DateTime clm_date_time { get; set; }
        public string clm_user { get; set; }

    }
    public class IOT_DEVICE_EDC_031
    {

        public int id { get; set; }
        public string device_id { get; set; }
        public string data_value_01 { get; set; }
        public string data_value_02 { get; set; }
        public string data_value_03 { get; set; }
        public string data_value_04 { get; set; }
        public string data_value_05 { get; set; }
        public string data_value_06 { get; set; }
        public string data_value_07 { get; set; }
        public string data_value_08 { get; set; }
        public string data_value_09 { get; set; }
        public string data_value_10 { get; set; }
        public string data_value_11 { get; set; }
        public string data_value_12 { get; set; }
        public string data_value_13 { get; set; }
        public string data_value_14 { get; set; }
        public string data_value_15 { get; set; }
        public string data_value_16 { get; set; }
        public string data_value_17 { get; set; }
        public string data_value_18 { get; set; }
        public string data_value_19 { get; set; }
        public string data_value_20 { get; set; }
        public string data_value_21 { get; set; }
        public string data_value_22 { get; set; }
        public string data_value_23 { get; set; }
        public string data_value_24 { get; set; }
        public string data_value_25 { get; set; }
        public string data_value_26 { get; set; }
        public string data_value_27 { get; set; }
        public string data_value_28 { get; set; }
        public string data_value_29 { get; set; }
        public string data_value_30 { get; set; }
        public string data_value_31 { get; set; }
        public string data_value_32 { get; set; }
        public string data_value_33 { get; set; }
        public string data_value_34 { get; set; }
        public string data_value_35 { get; set; }
        public string data_value_36 { get; set; }
        public string data_value_37 { get; set; }
        public string data_value_38 { get; set; }
        public string data_value_39 { get; set; }
        public string data_value_40 { get; set; }
        public DateTime clm_date_time { get; set; }
        public string clm_user { get; set; }

    }
    public class IOT_DEVICE_EDC_032
    {

        public int id { get; set; }
        public string device_id { get; set; }
        public string data_value_01 { get; set; }
        public string data_value_02 { get; set; }
        public string data_value_03 { get; set; }
        public string data_value_04 { get; set; }
        public string data_value_05 { get; set; }
        public string data_value_06 { get; set; }
        public string data_value_07 { get; set; }
        public string data_value_08 { get; set; }
        public string data_value_09 { get; set; }
        public string data_value_10 { get; set; }
        public string data_value_11 { get; set; }
        public string data_value_12 { get; set; }
        public string data_value_13 { get; set; }
        public string data_value_14 { get; set; }
        public string data_value_15 { get; set; }
        public string data_value_16 { get; set; }
        public string data_value_17 { get; set; }
        public string data_value_18 { get; set; }
        public string data_value_19 { get; set; }
        public string data_value_20 { get; set; }
        public string data_value_21 { get; set; }
        public string data_value_22 { get; set; }
        public string data_value_23 { get; set; }
        public string data_value_24 { get; set; }
        public string data_value_25 { get; set; }
        public string data_value_26 { get; set; }
        public string data_value_27 { get; set; }
        public string data_value_28 { get; set; }
        public string data_value_29 { get; set; }
        public string data_value_30 { get; set; }
        public string data_value_31 { get; set; }
        public string data_value_32 { get; set; }
        public string data_value_33 { get; set; }
        public string data_value_34 { get; set; }
        public string data_value_35 { get; set; }
        public string data_value_36 { get; set; }
        public string data_value_37 { get; set; }
        public string data_value_38 { get; set; }
        public string data_value_39 { get; set; }
        public string data_value_40 { get; set; }
        public DateTime clm_date_time { get; set; }
        public string clm_user { get; set; }

    }
    public class IOT_DEVICE_EDC_033
    {

        public int id { get; set; }
        public string device_id { get; set; }
        public string data_value_01 { get; set; }
        public string data_value_02 { get; set; }
        public string data_value_03 { get; set; }
        public string data_value_04 { get; set; }
        public string data_value_05 { get; set; }
        public string data_value_06 { get; set; }
        public string data_value_07 { get; set; }
        public string data_value_08 { get; set; }
        public string data_value_09 { get; set; }
        public string data_value_10 { get; set; }
        public string data_value_11 { get; set; }
        public string data_value_12 { get; set; }
        public string data_value_13 { get; set; }
        public string data_value_14 { get; set; }
        public string data_value_15 { get; set; }
        public string data_value_16 { get; set; }
        public string data_value_17 { get; set; }
        public string data_value_18 { get; set; }
        public string data_value_19 { get; set; }
        public string data_value_20 { get; set; }
        public string data_value_21 { get; set; }
        public string data_value_22 { get; set; }
        public string data_value_23 { get; set; }
        public string data_value_24 { get; set; }
        public string data_value_25 { get; set; }
        public string data_value_26 { get; set; }
        public string data_value_27 { get; set; }
        public string data_value_28 { get; set; }
        public string data_value_29 { get; set; }
        public string data_value_30 { get; set; }
        public string data_value_31 { get; set; }
        public string data_value_32 { get; set; }
        public string data_value_33 { get; set; }
        public string data_value_34 { get; set; }
        public string data_value_35 { get; set; }
        public string data_value_36 { get; set; }
        public string data_value_37 { get; set; }
        public string data_value_38 { get; set; }
        public string data_value_39 { get; set; }
        public string data_value_40 { get; set; }
        public DateTime clm_date_time { get; set; }
        public string clm_user { get; set; }

    }
    public class IOT_DEVICE_EDC_034
    {

        public int id { get; set; }
        public string device_id { get; set; }
        public string data_value_01 { get; set; }
        public string data_value_02 { get; set; }
        public string data_value_03 { get; set; }
        public string data_value_04 { get; set; }
        public string data_value_05 { get; set; }
        public string data_value_06 { get; set; }
        public string data_value_07 { get; set; }
        public string data_value_08 { get; set; }
        public string data_value_09 { get; set; }
        public string data_value_10 { get; set; }
        public string data_value_11 { get; set; }
        public string data_value_12 { get; set; }
        public string data_value_13 { get; set; }
        public string data_value_14 { get; set; }
        public string data_value_15 { get; set; }
        public string data_value_16 { get; set; }
        public string data_value_17 { get; set; }
        public string data_value_18 { get; set; }
        public string data_value_19 { get; set; }
        public string data_value_20 { get; set; }
        public string data_value_21 { get; set; }
        public string data_value_22 { get; set; }
        public string data_value_23 { get; set; }
        public string data_value_24 { get; set; }
        public string data_value_25 { get; set; }
        public string data_value_26 { get; set; }
        public string data_value_27 { get; set; }
        public string data_value_28 { get; set; }
        public string data_value_29 { get; set; }
        public string data_value_30 { get; set; }
        public string data_value_31 { get; set; }
        public string data_value_32 { get; set; }
        public string data_value_33 { get; set; }
        public string data_value_34 { get; set; }
        public string data_value_35 { get; set; }
        public string data_value_36 { get; set; }
        public string data_value_37 { get; set; }
        public string data_value_38 { get; set; }
        public string data_value_39 { get; set; }
        public string data_value_40 { get; set; }
        public DateTime clm_date_time { get; set; }
        public string clm_user { get; set; }

    }
    public class IOT_DEVICE_EDC_035
    {

        public int id { get; set; }
        public string device_id { get; set; }
        public string data_value_01 { get; set; }
        public string data_value_02 { get; set; }
        public string data_value_03 { get; set; }
        public string data_value_04 { get; set; }
        public string data_value_05 { get; set; }
        public string data_value_06 { get; set; }
        public string data_value_07 { get; set; }
        public string data_value_08 { get; set; }
        public string data_value_09 { get; set; }
        public string data_value_10 { get; set; }
        public string data_value_11 { get; set; }
        public string data_value_12 { get; set; }
        public string data_value_13 { get; set; }
        public string data_value_14 { get; set; }
        public string data_value_15 { get; set; }
        public string data_value_16 { get; set; }
        public string data_value_17 { get; set; }
        public string data_value_18 { get; set; }
        public string data_value_19 { get; set; }
        public string data_value_20 { get; set; }
        public string data_value_21 { get; set; }
        public string data_value_22 { get; set; }
        public string data_value_23 { get; set; }
        public string data_value_24 { get; set; }
        public string data_value_25 { get; set; }
        public string data_value_26 { get; set; }
        public string data_value_27 { get; set; }
        public string data_value_28 { get; set; }
        public string data_value_29 { get; set; }
        public string data_value_30 { get; set; }
        public string data_value_31 { get; set; }
        public string data_value_32 { get; set; }
        public string data_value_33 { get; set; }
        public string data_value_34 { get; set; }
        public string data_value_35 { get; set; }
        public string data_value_36 { get; set; }
        public string data_value_37 { get; set; }
        public string data_value_38 { get; set; }
        public string data_value_39 { get; set; }
        public string data_value_40 { get; set; }
        public DateTime clm_date_time { get; set; }
        public string clm_user { get; set; }

    }
    public class IOT_DEVICE_EDC_036
    {

        public int id { get; set; }
        public string device_id { get; set; }
        public string data_value_01 { get; set; }
        public string data_value_02 { get; set; }
        public string data_value_03 { get; set; }
        public string data_value_04 { get; set; }
        public string data_value_05 { get; set; }
        public string data_value_06 { get; set; }
        public string data_value_07 { get; set; }
        public string data_value_08 { get; set; }
        public string data_value_09 { get; set; }
        public string data_value_10 { get; set; }
        public string data_value_11 { get; set; }
        public string data_value_12 { get; set; }
        public string data_value_13 { get; set; }
        public string data_value_14 { get; set; }
        public string data_value_15 { get; set; }
        public string data_value_16 { get; set; }
        public string data_value_17 { get; set; }
        public string data_value_18 { get; set; }
        public string data_value_19 { get; set; }
        public string data_value_20 { get; set; }
        public string data_value_21 { get; set; }
        public string data_value_22 { get; set; }
        public string data_value_23 { get; set; }
        public string data_value_24 { get; set; }
        public string data_value_25 { get; set; }
        public string data_value_26 { get; set; }
        public string data_value_27 { get; set; }
        public string data_value_28 { get; set; }
        public string data_value_29 { get; set; }
        public string data_value_30 { get; set; }
        public string data_value_31 { get; set; }
        public string data_value_32 { get; set; }
        public string data_value_33 { get; set; }
        public string data_value_34 { get; set; }
        public string data_value_35 { get; set; }
        public string data_value_36 { get; set; }
        public string data_value_37 { get; set; }
        public string data_value_38 { get; set; }
        public string data_value_39 { get; set; }
        public string data_value_40 { get; set; }
        public DateTime clm_date_time { get; set; }
        public string clm_user { get; set; }

    }
    public class IOT_DEVICE_EDC_037
    {

        public int id { get; set; }
        public string device_id { get; set; }
        public string data_value_01 { get; set; }
        public string data_value_02 { get; set; }
        public string data_value_03 { get; set; }
        public string data_value_04 { get; set; }
        public string data_value_05 { get; set; }
        public string data_value_06 { get; set; }
        public string data_value_07 { get; set; }
        public string data_value_08 { get; set; }
        public string data_value_09 { get; set; }
        public string data_value_10 { get; set; }
        public string data_value_11 { get; set; }
        public string data_value_12 { get; set; }
        public string data_value_13 { get; set; }
        public string data_value_14 { get; set; }
        public string data_value_15 { get; set; }
        public string data_value_16 { get; set; }
        public string data_value_17 { get; set; }
        public string data_value_18 { get; set; }
        public string data_value_19 { get; set; }
        public string data_value_20 { get; set; }
        public string data_value_21 { get; set; }
        public string data_value_22 { get; set; }
        public string data_value_23 { get; set; }
        public string data_value_24 { get; set; }
        public string data_value_25 { get; set; }
        public string data_value_26 { get; set; }
        public string data_value_27 { get; set; }
        public string data_value_28 { get; set; }
        public string data_value_29 { get; set; }
        public string data_value_30 { get; set; }
        public string data_value_31 { get; set; }
        public string data_value_32 { get; set; }
        public string data_value_33 { get; set; }
        public string data_value_34 { get; set; }
        public string data_value_35 { get; set; }
        public string data_value_36 { get; set; }
        public string data_value_37 { get; set; }
        public string data_value_38 { get; set; }
        public string data_value_39 { get; set; }
        public string data_value_40 { get; set; }
        public DateTime clm_date_time { get; set; }
        public string clm_user { get; set; }

    }
    public class IOT_DEVICE_EDC_038
    {

        public int id { get; set; }
        public string device_id { get; set; }
        public string data_value_01 { get; set; }
        public string data_value_02 { get; set; }
        public string data_value_03 { get; set; }
        public string data_value_04 { get; set; }
        public string data_value_05 { get; set; }
        public string data_value_06 { get; set; }
        public string data_value_07 { get; set; }
        public string data_value_08 { get; set; }
        public string data_value_09 { get; set; }
        public string data_value_10 { get; set; }
        public string data_value_11 { get; set; }
        public string data_value_12 { get; set; }
        public string data_value_13 { get; set; }
        public string data_value_14 { get; set; }
        public string data_value_15 { get; set; }
        public string data_value_16 { get; set; }
        public string data_value_17 { get; set; }
        public string data_value_18 { get; set; }
        public string data_value_19 { get; set; }
        public string data_value_20 { get; set; }
        public string data_value_21 { get; set; }
        public string data_value_22 { get; set; }
        public string data_value_23 { get; set; }
        public string data_value_24 { get; set; }
        public string data_value_25 { get; set; }
        public string data_value_26 { get; set; }
        public string data_value_27 { get; set; }
        public string data_value_28 { get; set; }
        public string data_value_29 { get; set; }
        public string data_value_30 { get; set; }
        public string data_value_31 { get; set; }
        public string data_value_32 { get; set; }
        public string data_value_33 { get; set; }
        public string data_value_34 { get; set; }
        public string data_value_35 { get; set; }
        public string data_value_36 { get; set; }
        public string data_value_37 { get; set; }
        public string data_value_38 { get; set; }
        public string data_value_39 { get; set; }
        public string data_value_40 { get; set; }
        public DateTime clm_date_time { get; set; }
        public string clm_user { get; set; }

    }
    public class IOT_DEVICE_EDC_039
    {

        public int id { get; set; }
        public string device_id { get; set; }
        public string data_value_01 { get; set; }
        public string data_value_02 { get; set; }
        public string data_value_03 { get; set; }
        public string data_value_04 { get; set; }
        public string data_value_05 { get; set; }
        public string data_value_06 { get; set; }
        public string data_value_07 { get; set; }
        public string data_value_08 { get; set; }
        public string data_value_09 { get; set; }
        public string data_value_10 { get; set; }
        public string data_value_11 { get; set; }
        public string data_value_12 { get; set; }
        public string data_value_13 { get; set; }
        public string data_value_14 { get; set; }
        public string data_value_15 { get; set; }
        public string data_value_16 { get; set; }
        public string data_value_17 { get; set; }
        public string data_value_18 { get; set; }
        public string data_value_19 { get; set; }
        public string data_value_20 { get; set; }
        public string data_value_21 { get; set; }
        public string data_value_22 { get; set; }
        public string data_value_23 { get; set; }
        public string data_value_24 { get; set; }
        public string data_value_25 { get; set; }
        public string data_value_26 { get; set; }
        public string data_value_27 { get; set; }
        public string data_value_28 { get; set; }
        public string data_value_29 { get; set; }
        public string data_value_30 { get; set; }
        public string data_value_31 { get; set; }
        public string data_value_32 { get; set; }
        public string data_value_33 { get; set; }
        public string data_value_34 { get; set; }
        public string data_value_35 { get; set; }
        public string data_value_36 { get; set; }
        public string data_value_37 { get; set; }
        public string data_value_38 { get; set; }
        public string data_value_39 { get; set; }
        public string data_value_40 { get; set; }
        public DateTime clm_date_time { get; set; }
        public string clm_user { get; set; }

    }
    public class IOT_DEVICE_EDC_040
    {

        public int id { get; set; }
        public string device_id { get; set; }
        public string data_value_01 { get; set; }
        public string data_value_02 { get; set; }
        public string data_value_03 { get; set; }
        public string data_value_04 { get; set; }
        public string data_value_05 { get; set; }
        public string data_value_06 { get; set; }
        public string data_value_07 { get; set; }
        public string data_value_08 { get; set; }
        public string data_value_09 { get; set; }
        public string data_value_10 { get; set; }
        public string data_value_11 { get; set; }
        public string data_value_12 { get; set; }
        public string data_value_13 { get; set; }
        public string data_value_14 { get; set; }
        public string data_value_15 { get; set; }
        public string data_value_16 { get; set; }
        public string data_value_17 { get; set; }
        public string data_value_18 { get; set; }
        public string data_value_19 { get; set; }
        public string data_value_20 { get; set; }
        public string data_value_21 { get; set; }
        public string data_value_22 { get; set; }
        public string data_value_23 { get; set; }
        public string data_value_24 { get; set; }
        public string data_value_25 { get; set; }
        public string data_value_26 { get; set; }
        public string data_value_27 { get; set; }
        public string data_value_28 { get; set; }
        public string data_value_29 { get; set; }
        public string data_value_30 { get; set; }
        public string data_value_31 { get; set; }
        public string data_value_32 { get; set; }
        public string data_value_33 { get; set; }
        public string data_value_34 { get; set; }
        public string data_value_35 { get; set; }
        public string data_value_36 { get; set; }
        public string data_value_37 { get; set; }
        public string data_value_38 { get; set; }
        public string data_value_39 { get; set; }
        public string data_value_40 { get; set; }
        public DateTime clm_date_time { get; set; }
        public string clm_user { get; set; }

    }
    public class IOT_DEVICE_EDC_041
    {

        public int id { get; set; }
        public string device_id { get; set; }
        public string data_value_01 { get; set; }
        public string data_value_02 { get; set; }
        public string data_value_03 { get; set; }
        public string data_value_04 { get; set; }
        public string data_value_05 { get; set; }
        public string data_value_06 { get; set; }
        public string data_value_07 { get; set; }
        public string data_value_08 { get; set; }
        public string data_value_09 { get; set; }
        public string data_value_10 { get; set; }
        public string data_value_11 { get; set; }
        public string data_value_12 { get; set; }
        public string data_value_13 { get; set; }
        public string data_value_14 { get; set; }
        public string data_value_15 { get; set; }
        public string data_value_16 { get; set; }
        public string data_value_17 { get; set; }
        public string data_value_18 { get; set; }
        public string data_value_19 { get; set; }
        public string data_value_20 { get; set; }
        public string data_value_21 { get; set; }
        public string data_value_22 { get; set; }
        public string data_value_23 { get; set; }
        public string data_value_24 { get; set; }
        public string data_value_25 { get; set; }
        public string data_value_26 { get; set; }
        public string data_value_27 { get; set; }
        public string data_value_28 { get; set; }
        public string data_value_29 { get; set; }
        public string data_value_30 { get; set; }
        public string data_value_31 { get; set; }
        public string data_value_32 { get; set; }
        public string data_value_33 { get; set; }
        public string data_value_34 { get; set; }
        public string data_value_35 { get; set; }
        public string data_value_36 { get; set; }
        public string data_value_37 { get; set; }
        public string data_value_38 { get; set; }
        public string data_value_39 { get; set; }
        public string data_value_40 { get; set; }
        public DateTime clm_date_time { get; set; }
        public string clm_user { get; set; }

    }
    public class IOT_DEVICE_EDC_042
    {

        public int id { get; set; }
        public string device_id { get; set; }
        public string data_value_01 { get; set; }
        public string data_value_02 { get; set; }
        public string data_value_03 { get; set; }
        public string data_value_04 { get; set; }
        public string data_value_05 { get; set; }
        public string data_value_06 { get; set; }
        public string data_value_07 { get; set; }
        public string data_value_08 { get; set; }
        public string data_value_09 { get; set; }
        public string data_value_10 { get; set; }
        public string data_value_11 { get; set; }
        public string data_value_12 { get; set; }
        public string data_value_13 { get; set; }
        public string data_value_14 { get; set; }
        public string data_value_15 { get; set; }
        public string data_value_16 { get; set; }
        public string data_value_17 { get; set; }
        public string data_value_18 { get; set; }
        public string data_value_19 { get; set; }
        public string data_value_20 { get; set; }
        public string data_value_21 { get; set; }
        public string data_value_22 { get; set; }
        public string data_value_23 { get; set; }
        public string data_value_24 { get; set; }
        public string data_value_25 { get; set; }
        public string data_value_26 { get; set; }
        public string data_value_27 { get; set; }
        public string data_value_28 { get; set; }
        public string data_value_29 { get; set; }
        public string data_value_30 { get; set; }
        public string data_value_31 { get; set; }
        public string data_value_32 { get; set; }
        public string data_value_33 { get; set; }
        public string data_value_34 { get; set; }
        public string data_value_35 { get; set; }
        public string data_value_36 { get; set; }
        public string data_value_37 { get; set; }
        public string data_value_38 { get; set; }
        public string data_value_39 { get; set; }
        public string data_value_40 { get; set; }
        public DateTime clm_date_time { get; set; }
        public string clm_user { get; set; }

    }
    public class IOT_DEVICE_EDC_043
    {

        public int id { get; set; }
        public string device_id { get; set; }
        public string data_value_01 { get; set; }
        public string data_value_02 { get; set; }
        public string data_value_03 { get; set; }
        public string data_value_04 { get; set; }
        public string data_value_05 { get; set; }
        public string data_value_06 { get; set; }
        public string data_value_07 { get; set; }
        public string data_value_08 { get; set; }
        public string data_value_09 { get; set; }
        public string data_value_10 { get; set; }
        public string data_value_11 { get; set; }
        public string data_value_12 { get; set; }
        public string data_value_13 { get; set; }
        public string data_value_14 { get; set; }
        public string data_value_15 { get; set; }
        public string data_value_16 { get; set; }
        public string data_value_17 { get; set; }
        public string data_value_18 { get; set; }
        public string data_value_19 { get; set; }
        public string data_value_20 { get; set; }
        public string data_value_21 { get; set; }
        public string data_value_22 { get; set; }
        public string data_value_23 { get; set; }
        public string data_value_24 { get; set; }
        public string data_value_25 { get; set; }
        public string data_value_26 { get; set; }
        public string data_value_27 { get; set; }
        public string data_value_28 { get; set; }
        public string data_value_29 { get; set; }
        public string data_value_30 { get; set; }
        public string data_value_31 { get; set; }
        public string data_value_32 { get; set; }
        public string data_value_33 { get; set; }
        public string data_value_34 { get; set; }
        public string data_value_35 { get; set; }
        public string data_value_36 { get; set; }
        public string data_value_37 { get; set; }
        public string data_value_38 { get; set; }
        public string data_value_39 { get; set; }
        public string data_value_40 { get; set; }
        public DateTime clm_date_time { get; set; }
        public string clm_user { get; set; }

    }
    public class IOT_DEVICE_EDC_044
    {

        public int id { get; set; }
        public string device_id { get; set; }
        public string data_value_01 { get; set; }
        public string data_value_02 { get; set; }
        public string data_value_03 { get; set; }
        public string data_value_04 { get; set; }
        public string data_value_05 { get; set; }
        public string data_value_06 { get; set; }
        public string data_value_07 { get; set; }
        public string data_value_08 { get; set; }
        public string data_value_09 { get; set; }
        public string data_value_10 { get; set; }
        public string data_value_11 { get; set; }
        public string data_value_12 { get; set; }
        public string data_value_13 { get; set; }
        public string data_value_14 { get; set; }
        public string data_value_15 { get; set; }
        public string data_value_16 { get; set; }
        public string data_value_17 { get; set; }
        public string data_value_18 { get; set; }
        public string data_value_19 { get; set; }
        public string data_value_20 { get; set; }
        public string data_value_21 { get; set; }
        public string data_value_22 { get; set; }
        public string data_value_23 { get; set; }
        public string data_value_24 { get; set; }
        public string data_value_25 { get; set; }
        public string data_value_26 { get; set; }
        public string data_value_27 { get; set; }
        public string data_value_28 { get; set; }
        public string data_value_29 { get; set; }
        public string data_value_30 { get; set; }
        public string data_value_31 { get; set; }
        public string data_value_32 { get; set; }
        public string data_value_33 { get; set; }
        public string data_value_34 { get; set; }
        public string data_value_35 { get; set; }
        public string data_value_36 { get; set; }
        public string data_value_37 { get; set; }
        public string data_value_38 { get; set; }
        public string data_value_39 { get; set; }
        public string data_value_40 { get; set; }
        public DateTime clm_date_time { get; set; }
        public string clm_user { get; set; }

    }
    public class IOT_DEVICE_EDC_045
    {

        public int id { get; set; }
        public string device_id { get; set; }
        public string data_value_01 { get; set; }
        public string data_value_02 { get; set; }
        public string data_value_03 { get; set; }
        public string data_value_04 { get; set; }
        public string data_value_05 { get; set; }
        public string data_value_06 { get; set; }
        public string data_value_07 { get; set; }
        public string data_value_08 { get; set; }
        public string data_value_09 { get; set; }
        public string data_value_10 { get; set; }
        public string data_value_11 { get; set; }
        public string data_value_12 { get; set; }
        public string data_value_13 { get; set; }
        public string data_value_14 { get; set; }
        public string data_value_15 { get; set; }
        public string data_value_16 { get; set; }
        public string data_value_17 { get; set; }
        public string data_value_18 { get; set; }
        public string data_value_19 { get; set; }
        public string data_value_20 { get; set; }
        public string data_value_21 { get; set; }
        public string data_value_22 { get; set; }
        public string data_value_23 { get; set; }
        public string data_value_24 { get; set; }
        public string data_value_25 { get; set; }
        public string data_value_26 { get; set; }
        public string data_value_27 { get; set; }
        public string data_value_28 { get; set; }
        public string data_value_29 { get; set; }
        public string data_value_30 { get; set; }
        public string data_value_31 { get; set; }
        public string data_value_32 { get; set; }
        public string data_value_33 { get; set; }
        public string data_value_34 { get; set; }
        public string data_value_35 { get; set; }
        public string data_value_36 { get; set; }
        public string data_value_37 { get; set; }
        public string data_value_38 { get; set; }
        public string data_value_39 { get; set; }
        public string data_value_40 { get; set; }
        public DateTime clm_date_time { get; set; }
        public string clm_user { get; set; }

    }
    public class IOT_DEVICE_EDC_046
    {

        public int id { get; set; }
        public string device_id { get; set; }
        public string data_value_01 { get; set; }
        public string data_value_02 { get; set; }
        public string data_value_03 { get; set; }
        public string data_value_04 { get; set; }
        public string data_value_05 { get; set; }
        public string data_value_06 { get; set; }
        public string data_value_07 { get; set; }
        public string data_value_08 { get; set; }
        public string data_value_09 { get; set; }
        public string data_value_10 { get; set; }
        public string data_value_11 { get; set; }
        public string data_value_12 { get; set; }
        public string data_value_13 { get; set; }
        public string data_value_14 { get; set; }
        public string data_value_15 { get; set; }
        public string data_value_16 { get; set; }
        public string data_value_17 { get; set; }
        public string data_value_18 { get; set; }
        public string data_value_19 { get; set; }
        public string data_value_20 { get; set; }
        public string data_value_21 { get; set; }
        public string data_value_22 { get; set; }
        public string data_value_23 { get; set; }
        public string data_value_24 { get; set; }
        public string data_value_25 { get; set; }
        public string data_value_26 { get; set; }
        public string data_value_27 { get; set; }
        public string data_value_28 { get; set; }
        public string data_value_29 { get; set; }
        public string data_value_30 { get; set; }
        public string data_value_31 { get; set; }
        public string data_value_32 { get; set; }
        public string data_value_33 { get; set; }
        public string data_value_34 { get; set; }
        public string data_value_35 { get; set; }
        public string data_value_36 { get; set; }
        public string data_value_37 { get; set; }
        public string data_value_38 { get; set; }
        public string data_value_39 { get; set; }
        public string data_value_40 { get; set; }
        public DateTime clm_date_time { get; set; }
        public string clm_user { get; set; }

    }
    public class IOT_DEVICE_EDC_047
    {

        public int id { get; set; }
        public string device_id { get; set; }
        public string data_value_01 { get; set; }
        public string data_value_02 { get; set; }
        public string data_value_03 { get; set; }
        public string data_value_04 { get; set; }
        public string data_value_05 { get; set; }
        public string data_value_06 { get; set; }
        public string data_value_07 { get; set; }
        public string data_value_08 { get; set; }
        public string data_value_09 { get; set; }
        public string data_value_10 { get; set; }
        public string data_value_11 { get; set; }
        public string data_value_12 { get; set; }
        public string data_value_13 { get; set; }
        public string data_value_14 { get; set; }
        public string data_value_15 { get; set; }
        public string data_value_16 { get; set; }
        public string data_value_17 { get; set; }
        public string data_value_18 { get; set; }
        public string data_value_19 { get; set; }
        public string data_value_20 { get; set; }
        public string data_value_21 { get; set; }
        public string data_value_22 { get; set; }
        public string data_value_23 { get; set; }
        public string data_value_24 { get; set; }
        public string data_value_25 { get; set; }
        public string data_value_26 { get; set; }
        public string data_value_27 { get; set; }
        public string data_value_28 { get; set; }
        public string data_value_29 { get; set; }
        public string data_value_30 { get; set; }
        public string data_value_31 { get; set; }
        public string data_value_32 { get; set; }
        public string data_value_33 { get; set; }
        public string data_value_34 { get; set; }
        public string data_value_35 { get; set; }
        public string data_value_36 { get; set; }
        public string data_value_37 { get; set; }
        public string data_value_38 { get; set; }
        public string data_value_39 { get; set; }
        public string data_value_40 { get; set; }
        public DateTime clm_date_time { get; set; }
        public string clm_user { get; set; }

    }
    public class IOT_DEVICE_EDC_048
    {

        public int id { get; set; }
        public string device_id { get; set; }
        public string data_value_01 { get; set; }
        public string data_value_02 { get; set; }
        public string data_value_03 { get; set; }
        public string data_value_04 { get; set; }
        public string data_value_05 { get; set; }
        public string data_value_06 { get; set; }
        public string data_value_07 { get; set; }
        public string data_value_08 { get; set; }
        public string data_value_09 { get; set; }
        public string data_value_10 { get; set; }
        public string data_value_11 { get; set; }
        public string data_value_12 { get; set; }
        public string data_value_13 { get; set; }
        public string data_value_14 { get; set; }
        public string data_value_15 { get; set; }
        public string data_value_16 { get; set; }
        public string data_value_17 { get; set; }
        public string data_value_18 { get; set; }
        public string data_value_19 { get; set; }
        public string data_value_20 { get; set; }
        public string data_value_21 { get; set; }
        public string data_value_22 { get; set; }
        public string data_value_23 { get; set; }
        public string data_value_24 { get; set; }
        public string data_value_25 { get; set; }
        public string data_value_26 { get; set; }
        public string data_value_27 { get; set; }
        public string data_value_28 { get; set; }
        public string data_value_29 { get; set; }
        public string data_value_30 { get; set; }
        public string data_value_31 { get; set; }
        public string data_value_32 { get; set; }
        public string data_value_33 { get; set; }
        public string data_value_34 { get; set; }
        public string data_value_35 { get; set; }
        public string data_value_36 { get; set; }
        public string data_value_37 { get; set; }
        public string data_value_38 { get; set; }
        public string data_value_39 { get; set; }
        public string data_value_40 { get; set; }
        public DateTime clm_date_time { get; set; }
        public string clm_user { get; set; }

    }
    public class IOT_DEVICE_EDC_049
    {

        public int id { get; set; }
        public string device_id { get; set; }
        public string data_value_01 { get; set; }
        public string data_value_02 { get; set; }
        public string data_value_03 { get; set; }
        public string data_value_04 { get; set; }
        public string data_value_05 { get; set; }
        public string data_value_06 { get; set; }
        public string data_value_07 { get; set; }
        public string data_value_08 { get; set; }
        public string data_value_09 { get; set; }
        public string data_value_10 { get; set; }
        public string data_value_11 { get; set; }
        public string data_value_12 { get; set; }
        public string data_value_13 { get; set; }
        public string data_value_14 { get; set; }
        public string data_value_15 { get; set; }
        public string data_value_16 { get; set; }
        public string data_value_17 { get; set; }
        public string data_value_18 { get; set; }
        public string data_value_19 { get; set; }
        public string data_value_20 { get; set; }
        public string data_value_21 { get; set; }
        public string data_value_22 { get; set; }
        public string data_value_23 { get; set; }
        public string data_value_24 { get; set; }
        public string data_value_25 { get; set; }
        public string data_value_26 { get; set; }
        public string data_value_27 { get; set; }
        public string data_value_28 { get; set; }
        public string data_value_29 { get; set; }
        public string data_value_30 { get; set; }
        public string data_value_31 { get; set; }
        public string data_value_32 { get; set; }
        public string data_value_33 { get; set; }
        public string data_value_34 { get; set; }
        public string data_value_35 { get; set; }
        public string data_value_36 { get; set; }
        public string data_value_37 { get; set; }
        public string data_value_38 { get; set; }
        public string data_value_39 { get; set; }
        public string data_value_40 { get; set; }
        public DateTime clm_date_time { get; set; }
        public string clm_user { get; set; }

    }
    public class IOT_DEVICE_EDC_050
    {

        public int id { get; set; }
        public string device_id { get; set; }
        public string data_value_01 { get; set; }
        public string data_value_02 { get; set; }
        public string data_value_03 { get; set; }
        public string data_value_04 { get; set; }
        public string data_value_05 { get; set; }
        public string data_value_06 { get; set; }
        public string data_value_07 { get; set; }
        public string data_value_08 { get; set; }
        public string data_value_09 { get; set; }
        public string data_value_10 { get; set; }
        public string data_value_11 { get; set; }
        public string data_value_12 { get; set; }
        public string data_value_13 { get; set; }
        public string data_value_14 { get; set; }
        public string data_value_15 { get; set; }
        public string data_value_16 { get; set; }
        public string data_value_17 { get; set; }
        public string data_value_18 { get; set; }
        public string data_value_19 { get; set; }
        public string data_value_20 { get; set; }
        public string data_value_21 { get; set; }
        public string data_value_22 { get; set; }
        public string data_value_23 { get; set; }
        public string data_value_24 { get; set; }
        public string data_value_25 { get; set; }
        public string data_value_26 { get; set; }
        public string data_value_27 { get; set; }
        public string data_value_28 { get; set; }
        public string data_value_29 { get; set; }
        public string data_value_30 { get; set; }
        public string data_value_31 { get; set; }
        public string data_value_32 { get; set; }
        public string data_value_33 { get; set; }
        public string data_value_34 { get; set; }
        public string data_value_35 { get; set; }
        public string data_value_36 { get; set; }
        public string data_value_37 { get; set; }
        public string data_value_38 { get; set; }
        public string data_value_39 { get; set; }
        public string data_value_40 { get; set; }
        public DateTime clm_date_time { get; set; }
        public string clm_user { get; set; }

    }
    public class IOT_DEVICE_EDC_051
    {

        public int id { get; set; }
        public string device_id { get; set; }
        public string data_value_01 { get; set; }
        public string data_value_02 { get; set; }
        public string data_value_03 { get; set; }
        public string data_value_04 { get; set; }
        public string data_value_05 { get; set; }
        public string data_value_06 { get; set; }
        public string data_value_07 { get; set; }
        public string data_value_08 { get; set; }
        public string data_value_09 { get; set; }
        public string data_value_10 { get; set; }
        public string data_value_11 { get; set; }
        public string data_value_12 { get; set; }
        public string data_value_13 { get; set; }
        public string data_value_14 { get; set; }
        public string data_value_15 { get; set; }
        public string data_value_16 { get; set; }
        public string data_value_17 { get; set; }
        public string data_value_18 { get; set; }
        public string data_value_19 { get; set; }
        public string data_value_20 { get; set; }
        public string data_value_21 { get; set; }
        public string data_value_22 { get; set; }
        public string data_value_23 { get; set; }
        public string data_value_24 { get; set; }
        public string data_value_25 { get; set; }
        public string data_value_26 { get; set; }
        public string data_value_27 { get; set; }
        public string data_value_28 { get; set; }
        public string data_value_29 { get; set; }
        public string data_value_30 { get; set; }
        public string data_value_31 { get; set; }
        public string data_value_32 { get; set; }
        public string data_value_33 { get; set; }
        public string data_value_34 { get; set; }
        public string data_value_35 { get; set; }
        public string data_value_36 { get; set; }
        public string data_value_37 { get; set; }
        public string data_value_38 { get; set; }
        public string data_value_39 { get; set; }
        public string data_value_40 { get; set; }
        public DateTime clm_date_time { get; set; }
        public string clm_user { get; set; }

    }
    public class IOT_DEVICE_EDC_052
    {

        public int id { get; set; }
        public string device_id { get; set; }
        public string data_value_01 { get; set; }
        public string data_value_02 { get; set; }
        public string data_value_03 { get; set; }
        public string data_value_04 { get; set; }
        public string data_value_05 { get; set; }
        public string data_value_06 { get; set; }
        public string data_value_07 { get; set; }
        public string data_value_08 { get; set; }
        public string data_value_09 { get; set; }
        public string data_value_10 { get; set; }
        public string data_value_11 { get; set; }
        public string data_value_12 { get; set; }
        public string data_value_13 { get; set; }
        public string data_value_14 { get; set; }
        public string data_value_15 { get; set; }
        public string data_value_16 { get; set; }
        public string data_value_17 { get; set; }
        public string data_value_18 { get; set; }
        public string data_value_19 { get; set; }
        public string data_value_20 { get; set; }
        public string data_value_21 { get; set; }
        public string data_value_22 { get; set; }
        public string data_value_23 { get; set; }
        public string data_value_24 { get; set; }
        public string data_value_25 { get; set; }
        public string data_value_26 { get; set; }
        public string data_value_27 { get; set; }
        public string data_value_28 { get; set; }
        public string data_value_29 { get; set; }
        public string data_value_30 { get; set; }
        public string data_value_31 { get; set; }
        public string data_value_32 { get; set; }
        public string data_value_33 { get; set; }
        public string data_value_34 { get; set; }
        public string data_value_35 { get; set; }
        public string data_value_36 { get; set; }
        public string data_value_37 { get; set; }
        public string data_value_38 { get; set; }
        public string data_value_39 { get; set; }
        public string data_value_40 { get; set; }
        public DateTime clm_date_time { get; set; }
        public string clm_user { get; set; }

    }
    public class IOT_DEVICE_EDC_053
    {

        public int id { get; set; }
        public string device_id { get; set; }
        public string data_value_01 { get; set; }
        public string data_value_02 { get; set; }
        public string data_value_03 { get; set; }
        public string data_value_04 { get; set; }
        public string data_value_05 { get; set; }
        public string data_value_06 { get; set; }
        public string data_value_07 { get; set; }
        public string data_value_08 { get; set; }
        public string data_value_09 { get; set; }
        public string data_value_10 { get; set; }
        public string data_value_11 { get; set; }
        public string data_value_12 { get; set; }
        public string data_value_13 { get; set; }
        public string data_value_14 { get; set; }
        public string data_value_15 { get; set; }
        public string data_value_16 { get; set; }
        public string data_value_17 { get; set; }
        public string data_value_18 { get; set; }
        public string data_value_19 { get; set; }
        public string data_value_20 { get; set; }
        public string data_value_21 { get; set; }
        public string data_value_22 { get; set; }
        public string data_value_23 { get; set; }
        public string data_value_24 { get; set; }
        public string data_value_25 { get; set; }
        public string data_value_26 { get; set; }
        public string data_value_27 { get; set; }
        public string data_value_28 { get; set; }
        public string data_value_29 { get; set; }
        public string data_value_30 { get; set; }
        public string data_value_31 { get; set; }
        public string data_value_32 { get; set; }
        public string data_value_33 { get; set; }
        public string data_value_34 { get; set; }
        public string data_value_35 { get; set; }
        public string data_value_36 { get; set; }
        public string data_value_37 { get; set; }
        public string data_value_38 { get; set; }
        public string data_value_39 { get; set; }
        public string data_value_40 { get; set; }
        public DateTime clm_date_time { get; set; }
        public string clm_user { get; set; }

    }
    public class IOT_DEVICE_EDC_054
    {

        public int id { get; set; }
        public string device_id { get; set; }
        public string data_value_01 { get; set; }
        public string data_value_02 { get; set; }
        public string data_value_03 { get; set; }
        public string data_value_04 { get; set; }
        public string data_value_05 { get; set; }
        public string data_value_06 { get; set; }
        public string data_value_07 { get; set; }
        public string data_value_08 { get; set; }
        public string data_value_09 { get; set; }
        public string data_value_10 { get; set; }
        public string data_value_11 { get; set; }
        public string data_value_12 { get; set; }
        public string data_value_13 { get; set; }
        public string data_value_14 { get; set; }
        public string data_value_15 { get; set; }
        public string data_value_16 { get; set; }
        public string data_value_17 { get; set; }
        public string data_value_18 { get; set; }
        public string data_value_19 { get; set; }
        public string data_value_20 { get; set; }
        public string data_value_21 { get; set; }
        public string data_value_22 { get; set; }
        public string data_value_23 { get; set; }
        public string data_value_24 { get; set; }
        public string data_value_25 { get; set; }
        public string data_value_26 { get; set; }
        public string data_value_27 { get; set; }
        public string data_value_28 { get; set; }
        public string data_value_29 { get; set; }
        public string data_value_30 { get; set; }
        public string data_value_31 { get; set; }
        public string data_value_32 { get; set; }
        public string data_value_33 { get; set; }
        public string data_value_34 { get; set; }
        public string data_value_35 { get; set; }
        public string data_value_36 { get; set; }
        public string data_value_37 { get; set; }
        public string data_value_38 { get; set; }
        public string data_value_39 { get; set; }
        public string data_value_40 { get; set; }
        public DateTime clm_date_time { get; set; }
        public string clm_user { get; set; }

    }
    public class IOT_DEVICE_EDC_055
    {

        public int id { get; set; }
        public string device_id { get; set; }
        public string data_value_01 { get; set; }
        public string data_value_02 { get; set; }
        public string data_value_03 { get; set; }
        public string data_value_04 { get; set; }
        public string data_value_05 { get; set; }
        public string data_value_06 { get; set; }
        public string data_value_07 { get; set; }
        public string data_value_08 { get; set; }
        public string data_value_09 { get; set; }
        public string data_value_10 { get; set; }
        public string data_value_11 { get; set; }
        public string data_value_12 { get; set; }
        public string data_value_13 { get; set; }
        public string data_value_14 { get; set; }
        public string data_value_15 { get; set; }
        public string data_value_16 { get; set; }
        public string data_value_17 { get; set; }
        public string data_value_18 { get; set; }
        public string data_value_19 { get; set; }
        public string data_value_20 { get; set; }
        public string data_value_21 { get; set; }
        public string data_value_22 { get; set; }
        public string data_value_23 { get; set; }
        public string data_value_24 { get; set; }
        public string data_value_25 { get; set; }
        public string data_value_26 { get; set; }
        public string data_value_27 { get; set; }
        public string data_value_28 { get; set; }
        public string data_value_29 { get; set; }
        public string data_value_30 { get; set; }
        public string data_value_31 { get; set; }
        public string data_value_32 { get; set; }
        public string data_value_33 { get; set; }
        public string data_value_34 { get; set; }
        public string data_value_35 { get; set; }
        public string data_value_36 { get; set; }
        public string data_value_37 { get; set; }
        public string data_value_38 { get; set; }
        public string data_value_39 { get; set; }
        public string data_value_40 { get; set; }
        public DateTime clm_date_time { get; set; }
        public string clm_user { get; set; }

    }
    public class IOT_DEVICE_EDC_056
    {

        public int id { get; set; }
        public string device_id { get; set; }
        public string data_value_01 { get; set; }
        public string data_value_02 { get; set; }
        public string data_value_03 { get; set; }
        public string data_value_04 { get; set; }
        public string data_value_05 { get; set; }
        public string data_value_06 { get; set; }
        public string data_value_07 { get; set; }
        public string data_value_08 { get; set; }
        public string data_value_09 { get; set; }
        public string data_value_10 { get; set; }
        public string data_value_11 { get; set; }
        public string data_value_12 { get; set; }
        public string data_value_13 { get; set; }
        public string data_value_14 { get; set; }
        public string data_value_15 { get; set; }
        public string data_value_16 { get; set; }
        public string data_value_17 { get; set; }
        public string data_value_18 { get; set; }
        public string data_value_19 { get; set; }
        public string data_value_20 { get; set; }
        public string data_value_21 { get; set; }
        public string data_value_22 { get; set; }
        public string data_value_23 { get; set; }
        public string data_value_24 { get; set; }
        public string data_value_25 { get; set; }
        public string data_value_26 { get; set; }
        public string data_value_27 { get; set; }
        public string data_value_28 { get; set; }
        public string data_value_29 { get; set; }
        public string data_value_30 { get; set; }
        public string data_value_31 { get; set; }
        public string data_value_32 { get; set; }
        public string data_value_33 { get; set; }
        public string data_value_34 { get; set; }
        public string data_value_35 { get; set; }
        public string data_value_36 { get; set; }
        public string data_value_37 { get; set; }
        public string data_value_38 { get; set; }
        public string data_value_39 { get; set; }
        public string data_value_40 { get; set; }
        public DateTime clm_date_time { get; set; }
        public string clm_user { get; set; }

    }
    public class IOT_DEVICE_EDC_057
    {

        public int id { get; set; }
        public string device_id { get; set; }
        public string data_value_01 { get; set; }
        public string data_value_02 { get; set; }
        public string data_value_03 { get; set; }
        public string data_value_04 { get; set; }
        public string data_value_05 { get; set; }
        public string data_value_06 { get; set; }
        public string data_value_07 { get; set; }
        public string data_value_08 { get; set; }
        public string data_value_09 { get; set; }
        public string data_value_10 { get; set; }
        public string data_value_11 { get; set; }
        public string data_value_12 { get; set; }
        public string data_value_13 { get; set; }
        public string data_value_14 { get; set; }
        public string data_value_15 { get; set; }
        public string data_value_16 { get; set; }
        public string data_value_17 { get; set; }
        public string data_value_18 { get; set; }
        public string data_value_19 { get; set; }
        public string data_value_20 { get; set; }
        public string data_value_21 { get; set; }
        public string data_value_22 { get; set; }
        public string data_value_23 { get; set; }
        public string data_value_24 { get; set; }
        public string data_value_25 { get; set; }
        public string data_value_26 { get; set; }
        public string data_value_27 { get; set; }
        public string data_value_28 { get; set; }
        public string data_value_29 { get; set; }
        public string data_value_30 { get; set; }
        public string data_value_31 { get; set; }
        public string data_value_32 { get; set; }
        public string data_value_33 { get; set; }
        public string data_value_34 { get; set; }
        public string data_value_35 { get; set; }
        public string data_value_36 { get; set; }
        public string data_value_37 { get; set; }
        public string data_value_38 { get; set; }
        public string data_value_39 { get; set; }
        public string data_value_40 { get; set; }
        public DateTime clm_date_time { get; set; }
        public string clm_user { get; set; }

    }
    public class IOT_DEVICE_EDC_058
    {

        public int id { get; set; }
        public string device_id { get; set; }
        public string data_value_01 { get; set; }
        public string data_value_02 { get; set; }
        public string data_value_03 { get; set; }
        public string data_value_04 { get; set; }
        public string data_value_05 { get; set; }
        public string data_value_06 { get; set; }
        public string data_value_07 { get; set; }
        public string data_value_08 { get; set; }
        public string data_value_09 { get; set; }
        public string data_value_10 { get; set; }
        public string data_value_11 { get; set; }
        public string data_value_12 { get; set; }
        public string data_value_13 { get; set; }
        public string data_value_14 { get; set; }
        public string data_value_15 { get; set; }
        public string data_value_16 { get; set; }
        public string data_value_17 { get; set; }
        public string data_value_18 { get; set; }
        public string data_value_19 { get; set; }
        public string data_value_20 { get; set; }
        public string data_value_21 { get; set; }
        public string data_value_22 { get; set; }
        public string data_value_23 { get; set; }
        public string data_value_24 { get; set; }
        public string data_value_25 { get; set; }
        public string data_value_26 { get; set; }
        public string data_value_27 { get; set; }
        public string data_value_28 { get; set; }
        public string data_value_29 { get; set; }
        public string data_value_30 { get; set; }
        public string data_value_31 { get; set; }
        public string data_value_32 { get; set; }
        public string data_value_33 { get; set; }
        public string data_value_34 { get; set; }
        public string data_value_35 { get; set; }
        public string data_value_36 { get; set; }
        public string data_value_37 { get; set; }
        public string data_value_38 { get; set; }
        public string data_value_39 { get; set; }
        public string data_value_40 { get; set; }
        public DateTime clm_date_time { get; set; }
        public string clm_user { get; set; }

    }
    public class IOT_DEVICE_EDC_059
    {

        public int id { get; set; }
        public string device_id { get; set; }
        public string data_value_01 { get; set; }
        public string data_value_02 { get; set; }
        public string data_value_03 { get; set; }
        public string data_value_04 { get; set; }
        public string data_value_05 { get; set; }
        public string data_value_06 { get; set; }
        public string data_value_07 { get; set; }
        public string data_value_08 { get; set; }
        public string data_value_09 { get; set; }
        public string data_value_10 { get; set; }
        public string data_value_11 { get; set; }
        public string data_value_12 { get; set; }
        public string data_value_13 { get; set; }
        public string data_value_14 { get; set; }
        public string data_value_15 { get; set; }
        public string data_value_16 { get; set; }
        public string data_value_17 { get; set; }
        public string data_value_18 { get; set; }
        public string data_value_19 { get; set; }
        public string data_value_20 { get; set; }
        public string data_value_21 { get; set; }
        public string data_value_22 { get; set; }
        public string data_value_23 { get; set; }
        public string data_value_24 { get; set; }
        public string data_value_25 { get; set; }
        public string data_value_26 { get; set; }
        public string data_value_27 { get; set; }
        public string data_value_28 { get; set; }
        public string data_value_29 { get; set; }
        public string data_value_30 { get; set; }
        public string data_value_31 { get; set; }
        public string data_value_32 { get; set; }
        public string data_value_33 { get; set; }
        public string data_value_34 { get; set; }
        public string data_value_35 { get; set; }
        public string data_value_36 { get; set; }
        public string data_value_37 { get; set; }
        public string data_value_38 { get; set; }
        public string data_value_39 { get; set; }
        public string data_value_40 { get; set; }
        public DateTime clm_date_time { get; set; }
        public string clm_user { get; set; }

    }
    public class IOT_DEVICE_EDC_060
    {

        public int id { get; set; }
        public string device_id { get; set; }
        public string data_value_01 { get; set; }
        public string data_value_02 { get; set; }
        public string data_value_03 { get; set; }
        public string data_value_04 { get; set; }
        public string data_value_05 { get; set; }
        public string data_value_06 { get; set; }
        public string data_value_07 { get; set; }
        public string data_value_08 { get; set; }
        public string data_value_09 { get; set; }
        public string data_value_10 { get; set; }
        public string data_value_11 { get; set; }
        public string data_value_12 { get; set; }
        public string data_value_13 { get; set; }
        public string data_value_14 { get; set; }
        public string data_value_15 { get; set; }
        public string data_value_16 { get; set; }
        public string data_value_17 { get; set; }
        public string data_value_18 { get; set; }
        public string data_value_19 { get; set; }
        public string data_value_20 { get; set; }
        public string data_value_21 { get; set; }
        public string data_value_22 { get; set; }
        public string data_value_23 { get; set; }
        public string data_value_24 { get; set; }
        public string data_value_25 { get; set; }
        public string data_value_26 { get; set; }
        public string data_value_27 { get; set; }
        public string data_value_28 { get; set; }
        public string data_value_29 { get; set; }
        public string data_value_30 { get; set; }
        public string data_value_31 { get; set; }
        public string data_value_32 { get; set; }
        public string data_value_33 { get; set; }
        public string data_value_34 { get; set; }
        public string data_value_35 { get; set; }
        public string data_value_36 { get; set; }
        public string data_value_37 { get; set; }
        public string data_value_38 { get; set; }
        public string data_value_39 { get; set; }
        public string data_value_40 { get; set; }
        public DateTime clm_date_time { get; set; }
        public string clm_user { get; set; }

    }
    public class IOT_DEVICE_EDC_061
    {

        public int id { get; set; }
        public string device_id { get; set; }
        public string data_value_01 { get; set; }
        public string data_value_02 { get; set; }
        public string data_value_03 { get; set; }
        public string data_value_04 { get; set; }
        public string data_value_05 { get; set; }
        public string data_value_06 { get; set; }
        public string data_value_07 { get; set; }
        public string data_value_08 { get; set; }
        public string data_value_09 { get; set; }
        public string data_value_10 { get; set; }
        public string data_value_11 { get; set; }
        public string data_value_12 { get; set; }
        public string data_value_13 { get; set; }
        public string data_value_14 { get; set; }
        public string data_value_15 { get; set; }
        public string data_value_16 { get; set; }
        public string data_value_17 { get; set; }
        public string data_value_18 { get; set; }
        public string data_value_19 { get; set; }
        public string data_value_20 { get; set; }
        public string data_value_21 { get; set; }
        public string data_value_22 { get; set; }
        public string data_value_23 { get; set; }
        public string data_value_24 { get; set; }
        public string data_value_25 { get; set; }
        public string data_value_26 { get; set; }
        public string data_value_27 { get; set; }
        public string data_value_28 { get; set; }
        public string data_value_29 { get; set; }
        public string data_value_30 { get; set; }
        public string data_value_31 { get; set; }
        public string data_value_32 { get; set; }
        public string data_value_33 { get; set; }
        public string data_value_34 { get; set; }
        public string data_value_35 { get; set; }
        public string data_value_36 { get; set; }
        public string data_value_37 { get; set; }
        public string data_value_38 { get; set; }
        public string data_value_39 { get; set; }
        public string data_value_40 { get; set; }
        public DateTime clm_date_time { get; set; }
        public string clm_user { get; set; }

    }
    public class IOT_DEVICE_EDC_062
    {

        public int id { get; set; }
        public string device_id { get; set; }
        public string data_value_01 { get; set; }
        public string data_value_02 { get; set; }
        public string data_value_03 { get; set; }
        public string data_value_04 { get; set; }
        public string data_value_05 { get; set; }
        public string data_value_06 { get; set; }
        public string data_value_07 { get; set; }
        public string data_value_08 { get; set; }
        public string data_value_09 { get; set; }
        public string data_value_10 { get; set; }
        public string data_value_11 { get; set; }
        public string data_value_12 { get; set; }
        public string data_value_13 { get; set; }
        public string data_value_14 { get; set; }
        public string data_value_15 { get; set; }
        public string data_value_16 { get; set; }
        public string data_value_17 { get; set; }
        public string data_value_18 { get; set; }
        public string data_value_19 { get; set; }
        public string data_value_20 { get; set; }
        public string data_value_21 { get; set; }
        public string data_value_22 { get; set; }
        public string data_value_23 { get; set; }
        public string data_value_24 { get; set; }
        public string data_value_25 { get; set; }
        public string data_value_26 { get; set; }
        public string data_value_27 { get; set; }
        public string data_value_28 { get; set; }
        public string data_value_29 { get; set; }
        public string data_value_30 { get; set; }
        public string data_value_31 { get; set; }
        public string data_value_32 { get; set; }
        public string data_value_33 { get; set; }
        public string data_value_34 { get; set; }
        public string data_value_35 { get; set; }
        public string data_value_36 { get; set; }
        public string data_value_37 { get; set; }
        public string data_value_38 { get; set; }
        public string data_value_39 { get; set; }
        public string data_value_40 { get; set; }
        public DateTime clm_date_time { get; set; }
        public string clm_user { get; set; }

    }
    public class IOT_DEVICE_EDC_063
    {

        public int id { get; set; }
        public string device_id { get; set; }
        public string data_value_01 { get; set; }
        public string data_value_02 { get; set; }
        public string data_value_03 { get; set; }
        public string data_value_04 { get; set; }
        public string data_value_05 { get; set; }
        public string data_value_06 { get; set; }
        public string data_value_07 { get; set; }
        public string data_value_08 { get; set; }
        public string data_value_09 { get; set; }
        public string data_value_10 { get; set; }
        public string data_value_11 { get; set; }
        public string data_value_12 { get; set; }
        public string data_value_13 { get; set; }
        public string data_value_14 { get; set; }
        public string data_value_15 { get; set; }
        public string data_value_16 { get; set; }
        public string data_value_17 { get; set; }
        public string data_value_18 { get; set; }
        public string data_value_19 { get; set; }
        public string data_value_20 { get; set; }
        public string data_value_21 { get; set; }
        public string data_value_22 { get; set; }
        public string data_value_23 { get; set; }
        public string data_value_24 { get; set; }
        public string data_value_25 { get; set; }
        public string data_value_26 { get; set; }
        public string data_value_27 { get; set; }
        public string data_value_28 { get; set; }
        public string data_value_29 { get; set; }
        public string data_value_30 { get; set; }
        public string data_value_31 { get; set; }
        public string data_value_32 { get; set; }
        public string data_value_33 { get; set; }
        public string data_value_34 { get; set; }
        public string data_value_35 { get; set; }
        public string data_value_36 { get; set; }
        public string data_value_37 { get; set; }
        public string data_value_38 { get; set; }
        public string data_value_39 { get; set; }
        public string data_value_40 { get; set; }
        public DateTime clm_date_time { get; set; }
        public string clm_user { get; set; }

    }
    public class IOT_DEVICE_EDC_064
    {

        public int id { get; set; }
        public string device_id { get; set; }
        public string data_value_01 { get; set; }
        public string data_value_02 { get; set; }
        public string data_value_03 { get; set; }
        public string data_value_04 { get; set; }
        public string data_value_05 { get; set; }
        public string data_value_06 { get; set; }
        public string data_value_07 { get; set; }
        public string data_value_08 { get; set; }
        public string data_value_09 { get; set; }
        public string data_value_10 { get; set; }
        public string data_value_11 { get; set; }
        public string data_value_12 { get; set; }
        public string data_value_13 { get; set; }
        public string data_value_14 { get; set; }
        public string data_value_15 { get; set; }
        public string data_value_16 { get; set; }
        public string data_value_17 { get; set; }
        public string data_value_18 { get; set; }
        public string data_value_19 { get; set; }
        public string data_value_20 { get; set; }
        public string data_value_21 { get; set; }
        public string data_value_22 { get; set; }
        public string data_value_23 { get; set; }
        public string data_value_24 { get; set; }
        public string data_value_25 { get; set; }
        public string data_value_26 { get; set; }
        public string data_value_27 { get; set; }
        public string data_value_28 { get; set; }
        public string data_value_29 { get; set; }
        public string data_value_30 { get; set; }
        public string data_value_31 { get; set; }
        public string data_value_32 { get; set; }
        public string data_value_33 { get; set; }
        public string data_value_34 { get; set; }
        public string data_value_35 { get; set; }
        public string data_value_36 { get; set; }
        public string data_value_37 { get; set; }
        public string data_value_38 { get; set; }
        public string data_value_39 { get; set; }
        public string data_value_40 { get; set; }
        public DateTime clm_date_time { get; set; }
        public string clm_user { get; set; }

    }
    public class IOT_DEVICE_EDC_065
    {

        public int id { get; set; }
        public string device_id { get; set; }
        public string data_value_01 { get; set; }
        public string data_value_02 { get; set; }
        public string data_value_03 { get; set; }
        public string data_value_04 { get; set; }
        public string data_value_05 { get; set; }
        public string data_value_06 { get; set; }
        public string data_value_07 { get; set; }
        public string data_value_08 { get; set; }
        public string data_value_09 { get; set; }
        public string data_value_10 { get; set; }
        public string data_value_11 { get; set; }
        public string data_value_12 { get; set; }
        public string data_value_13 { get; set; }
        public string data_value_14 { get; set; }
        public string data_value_15 { get; set; }
        public string data_value_16 { get; set; }
        public string data_value_17 { get; set; }
        public string data_value_18 { get; set; }
        public string data_value_19 { get; set; }
        public string data_value_20 { get; set; }
        public string data_value_21 { get; set; }
        public string data_value_22 { get; set; }
        public string data_value_23 { get; set; }
        public string data_value_24 { get; set; }
        public string data_value_25 { get; set; }
        public string data_value_26 { get; set; }
        public string data_value_27 { get; set; }
        public string data_value_28 { get; set; }
        public string data_value_29 { get; set; }
        public string data_value_30 { get; set; }
        public string data_value_31 { get; set; }
        public string data_value_32 { get; set; }
        public string data_value_33 { get; set; }
        public string data_value_34 { get; set; }
        public string data_value_35 { get; set; }
        public string data_value_36 { get; set; }
        public string data_value_37 { get; set; }
        public string data_value_38 { get; set; }
        public string data_value_39 { get; set; }
        public string data_value_40 { get; set; }
        public DateTime clm_date_time { get; set; }
        public string clm_user { get; set; }

    }
    public class IOT_DEVICE_EDC_066
    {

        public int id { get; set; }
        public string device_id { get; set; }
        public string data_value_01 { get; set; }
        public string data_value_02 { get; set; }
        public string data_value_03 { get; set; }
        public string data_value_04 { get; set; }
        public string data_value_05 { get; set; }
        public string data_value_06 { get; set; }
        public string data_value_07 { get; set; }
        public string data_value_08 { get; set; }
        public string data_value_09 { get; set; }
        public string data_value_10 { get; set; }
        public string data_value_11 { get; set; }
        public string data_value_12 { get; set; }
        public string data_value_13 { get; set; }
        public string data_value_14 { get; set; }
        public string data_value_15 { get; set; }
        public string data_value_16 { get; set; }
        public string data_value_17 { get; set; }
        public string data_value_18 { get; set; }
        public string data_value_19 { get; set; }
        public string data_value_20 { get; set; }
        public string data_value_21 { get; set; }
        public string data_value_22 { get; set; }
        public string data_value_23 { get; set; }
        public string data_value_24 { get; set; }
        public string data_value_25 { get; set; }
        public string data_value_26 { get; set; }
        public string data_value_27 { get; set; }
        public string data_value_28 { get; set; }
        public string data_value_29 { get; set; }
        public string data_value_30 { get; set; }
        public string data_value_31 { get; set; }
        public string data_value_32 { get; set; }
        public string data_value_33 { get; set; }
        public string data_value_34 { get; set; }
        public string data_value_35 { get; set; }
        public string data_value_36 { get; set; }
        public string data_value_37 { get; set; }
        public string data_value_38 { get; set; }
        public string data_value_39 { get; set; }
        public string data_value_40 { get; set; }
        public DateTime clm_date_time { get; set; }
        public string clm_user { get; set; }

    }
    public class IOT_DEVICE_EDC_067
    {

        public int id { get; set; }
        public string device_id { get; set; }
        public string data_value_01 { get; set; }
        public string data_value_02 { get; set; }
        public string data_value_03 { get; set; }
        public string data_value_04 { get; set; }
        public string data_value_05 { get; set; }
        public string data_value_06 { get; set; }
        public string data_value_07 { get; set; }
        public string data_value_08 { get; set; }
        public string data_value_09 { get; set; }
        public string data_value_10 { get; set; }
        public string data_value_11 { get; set; }
        public string data_value_12 { get; set; }
        public string data_value_13 { get; set; }
        public string data_value_14 { get; set; }
        public string data_value_15 { get; set; }
        public string data_value_16 { get; set; }
        public string data_value_17 { get; set; }
        public string data_value_18 { get; set; }
        public string data_value_19 { get; set; }
        public string data_value_20 { get; set; }
        public string data_value_21 { get; set; }
        public string data_value_22 { get; set; }
        public string data_value_23 { get; set; }
        public string data_value_24 { get; set; }
        public string data_value_25 { get; set; }
        public string data_value_26 { get; set; }
        public string data_value_27 { get; set; }
        public string data_value_28 { get; set; }
        public string data_value_29 { get; set; }
        public string data_value_30 { get; set; }
        public string data_value_31 { get; set; }
        public string data_value_32 { get; set; }
        public string data_value_33 { get; set; }
        public string data_value_34 { get; set; }
        public string data_value_35 { get; set; }
        public string data_value_36 { get; set; }
        public string data_value_37 { get; set; }
        public string data_value_38 { get; set; }
        public string data_value_39 { get; set; }
        public string data_value_40 { get; set; }
        public DateTime clm_date_time { get; set; }
        public string clm_user { get; set; }

    }
    public class IOT_DEVICE_EDC_068
    {

        public int id { get; set; }
        public string device_id { get; set; }
        public string data_value_01 { get; set; }
        public string data_value_02 { get; set; }
        public string data_value_03 { get; set; }
        public string data_value_04 { get; set; }
        public string data_value_05 { get; set; }
        public string data_value_06 { get; set; }
        public string data_value_07 { get; set; }
        public string data_value_08 { get; set; }
        public string data_value_09 { get; set; }
        public string data_value_10 { get; set; }
        public string data_value_11 { get; set; }
        public string data_value_12 { get; set; }
        public string data_value_13 { get; set; }
        public string data_value_14 { get; set; }
        public string data_value_15 { get; set; }
        public string data_value_16 { get; set; }
        public string data_value_17 { get; set; }
        public string data_value_18 { get; set; }
        public string data_value_19 { get; set; }
        public string data_value_20 { get; set; }
        public string data_value_21 { get; set; }
        public string data_value_22 { get; set; }
        public string data_value_23 { get; set; }
        public string data_value_24 { get; set; }
        public string data_value_25 { get; set; }
        public string data_value_26 { get; set; }
        public string data_value_27 { get; set; }
        public string data_value_28 { get; set; }
        public string data_value_29 { get; set; }
        public string data_value_30 { get; set; }
        public string data_value_31 { get; set; }
        public string data_value_32 { get; set; }
        public string data_value_33 { get; set; }
        public string data_value_34 { get; set; }
        public string data_value_35 { get; set; }
        public string data_value_36 { get; set; }
        public string data_value_37 { get; set; }
        public string data_value_38 { get; set; }
        public string data_value_39 { get; set; }
        public string data_value_40 { get; set; }
        public DateTime clm_date_time { get; set; }
        public string clm_user { get; set; }

    }
    public class IOT_DEVICE_EDC_069
    {

        public int id { get; set; }
        public string device_id { get; set; }
        public string data_value_01 { get; set; }
        public string data_value_02 { get; set; }
        public string data_value_03 { get; set; }
        public string data_value_04 { get; set; }
        public string data_value_05 { get; set; }
        public string data_value_06 { get; set; }
        public string data_value_07 { get; set; }
        public string data_value_08 { get; set; }
        public string data_value_09 { get; set; }
        public string data_value_10 { get; set; }
        public string data_value_11 { get; set; }
        public string data_value_12 { get; set; }
        public string data_value_13 { get; set; }
        public string data_value_14 { get; set; }
        public string data_value_15 { get; set; }
        public string data_value_16 { get; set; }
        public string data_value_17 { get; set; }
        public string data_value_18 { get; set; }
        public string data_value_19 { get; set; }
        public string data_value_20 { get; set; }
        public string data_value_21 { get; set; }
        public string data_value_22 { get; set; }
        public string data_value_23 { get; set; }
        public string data_value_24 { get; set; }
        public string data_value_25 { get; set; }
        public string data_value_26 { get; set; }
        public string data_value_27 { get; set; }
        public string data_value_28 { get; set; }
        public string data_value_29 { get; set; }
        public string data_value_30 { get; set; }
        public string data_value_31 { get; set; }
        public string data_value_32 { get; set; }
        public string data_value_33 { get; set; }
        public string data_value_34 { get; set; }
        public string data_value_35 { get; set; }
        public string data_value_36 { get; set; }
        public string data_value_37 { get; set; }
        public string data_value_38 { get; set; }
        public string data_value_39 { get; set; }
        public string data_value_40 { get; set; }
        public DateTime clm_date_time { get; set; }
        public string clm_user { get; set; }

    }
    public class IOT_DEVICE_EDC_070
    {

        public int id { get; set; }
        public string device_id { get; set; }
        public string data_value_01 { get; set; }
        public string data_value_02 { get; set; }
        public string data_value_03 { get; set; }
        public string data_value_04 { get; set; }
        public string data_value_05 { get; set; }
        public string data_value_06 { get; set; }
        public string data_value_07 { get; set; }
        public string data_value_08 { get; set; }
        public string data_value_09 { get; set; }
        public string data_value_10 { get; set; }
        public string data_value_11 { get; set; }
        public string data_value_12 { get; set; }
        public string data_value_13 { get; set; }
        public string data_value_14 { get; set; }
        public string data_value_15 { get; set; }
        public string data_value_16 { get; set; }
        public string data_value_17 { get; set; }
        public string data_value_18 { get; set; }
        public string data_value_19 { get; set; }
        public string data_value_20 { get; set; }
        public string data_value_21 { get; set; }
        public string data_value_22 { get; set; }
        public string data_value_23 { get; set; }
        public string data_value_24 { get; set; }
        public string data_value_25 { get; set; }
        public string data_value_26 { get; set; }
        public string data_value_27 { get; set; }
        public string data_value_28 { get; set; }
        public string data_value_29 { get; set; }
        public string data_value_30 { get; set; }
        public string data_value_31 { get; set; }
        public string data_value_32 { get; set; }
        public string data_value_33 { get; set; }
        public string data_value_34 { get; set; }
        public string data_value_35 { get; set; }
        public string data_value_36 { get; set; }
        public string data_value_37 { get; set; }
        public string data_value_38 { get; set; }
        public string data_value_39 { get; set; }
        public string data_value_40 { get; set; }
        public DateTime clm_date_time { get; set; }
        public string clm_user { get; set; }

    }
    public class IOT_DEVICE_EDC_071
    {

        public int id { get; set; }
        public string device_id { get; set; }
        public string data_value_01 { get; set; }
        public string data_value_02 { get; set; }
        public string data_value_03 { get; set; }
        public string data_value_04 { get; set; }
        public string data_value_05 { get; set; }
        public string data_value_06 { get; set; }
        public string data_value_07 { get; set; }
        public string data_value_08 { get; set; }
        public string data_value_09 { get; set; }
        public string data_value_10 { get; set; }
        public string data_value_11 { get; set; }
        public string data_value_12 { get; set; }
        public string data_value_13 { get; set; }
        public string data_value_14 { get; set; }
        public string data_value_15 { get; set; }
        public string data_value_16 { get; set; }
        public string data_value_17 { get; set; }
        public string data_value_18 { get; set; }
        public string data_value_19 { get; set; }
        public string data_value_20 { get; set; }
        public string data_value_21 { get; set; }
        public string data_value_22 { get; set; }
        public string data_value_23 { get; set; }
        public string data_value_24 { get; set; }
        public string data_value_25 { get; set; }
        public string data_value_26 { get; set; }
        public string data_value_27 { get; set; }
        public string data_value_28 { get; set; }
        public string data_value_29 { get; set; }
        public string data_value_30 { get; set; }
        public string data_value_31 { get; set; }
        public string data_value_32 { get; set; }
        public string data_value_33 { get; set; }
        public string data_value_34 { get; set; }
        public string data_value_35 { get; set; }
        public string data_value_36 { get; set; }
        public string data_value_37 { get; set; }
        public string data_value_38 { get; set; }
        public string data_value_39 { get; set; }
        public string data_value_40 { get; set; }
        public DateTime clm_date_time { get; set; }
        public string clm_user { get; set; }

    }
    public class IOT_DEVICE_EDC_072
    {

        public int id { get; set; }
        public string device_id { get; set; }
        public string data_value_01 { get; set; }
        public string data_value_02 { get; set; }
        public string data_value_03 { get; set; }
        public string data_value_04 { get; set; }
        public string data_value_05 { get; set; }
        public string data_value_06 { get; set; }
        public string data_value_07 { get; set; }
        public string data_value_08 { get; set; }
        public string data_value_09 { get; set; }
        public string data_value_10 { get; set; }
        public string data_value_11 { get; set; }
        public string data_value_12 { get; set; }
        public string data_value_13 { get; set; }
        public string data_value_14 { get; set; }
        public string data_value_15 { get; set; }
        public string data_value_16 { get; set; }
        public string data_value_17 { get; set; }
        public string data_value_18 { get; set; }
        public string data_value_19 { get; set; }
        public string data_value_20 { get; set; }
        public string data_value_21 { get; set; }
        public string data_value_22 { get; set; }
        public string data_value_23 { get; set; }
        public string data_value_24 { get; set; }
        public string data_value_25 { get; set; }
        public string data_value_26 { get; set; }
        public string data_value_27 { get; set; }
        public string data_value_28 { get; set; }
        public string data_value_29 { get; set; }
        public string data_value_30 { get; set; }
        public string data_value_31 { get; set; }
        public string data_value_32 { get; set; }
        public string data_value_33 { get; set; }
        public string data_value_34 { get; set; }
        public string data_value_35 { get; set; }
        public string data_value_36 { get; set; }
        public string data_value_37 { get; set; }
        public string data_value_38 { get; set; }
        public string data_value_39 { get; set; }
        public string data_value_40 { get; set; }
        public DateTime clm_date_time { get; set; }
        public string clm_user { get; set; }

    }
    public class IOT_DEVICE_EDC_073
    {

        public int id { get; set; }
        public string device_id { get; set; }
        public string data_value_01 { get; set; }
        public string data_value_02 { get; set; }
        public string data_value_03 { get; set; }
        public string data_value_04 { get; set; }
        public string data_value_05 { get; set; }
        public string data_value_06 { get; set; }
        public string data_value_07 { get; set; }
        public string data_value_08 { get; set; }
        public string data_value_09 { get; set; }
        public string data_value_10 { get; set; }
        public string data_value_11 { get; set; }
        public string data_value_12 { get; set; }
        public string data_value_13 { get; set; }
        public string data_value_14 { get; set; }
        public string data_value_15 { get; set; }
        public string data_value_16 { get; set; }
        public string data_value_17 { get; set; }
        public string data_value_18 { get; set; }
        public string data_value_19 { get; set; }
        public string data_value_20 { get; set; }
        public string data_value_21 { get; set; }
        public string data_value_22 { get; set; }
        public string data_value_23 { get; set; }
        public string data_value_24 { get; set; }
        public string data_value_25 { get; set; }
        public string data_value_26 { get; set; }
        public string data_value_27 { get; set; }
        public string data_value_28 { get; set; }
        public string data_value_29 { get; set; }
        public string data_value_30 { get; set; }
        public string data_value_31 { get; set; }
        public string data_value_32 { get; set; }
        public string data_value_33 { get; set; }
        public string data_value_34 { get; set; }
        public string data_value_35 { get; set; }
        public string data_value_36 { get; set; }
        public string data_value_37 { get; set; }
        public string data_value_38 { get; set; }
        public string data_value_39 { get; set; }
        public string data_value_40 { get; set; }
        public DateTime clm_date_time { get; set; }
        public string clm_user { get; set; }

    }
    public class IOT_DEVICE_EDC_074
    {

        public int id { get; set; }
        public string device_id { get; set; }
        public string data_value_01 { get; set; }
        public string data_value_02 { get; set; }
        public string data_value_03 { get; set; }
        public string data_value_04 { get; set; }
        public string data_value_05 { get; set; }
        public string data_value_06 { get; set; }
        public string data_value_07 { get; set; }
        public string data_value_08 { get; set; }
        public string data_value_09 { get; set; }
        public string data_value_10 { get; set; }
        public string data_value_11 { get; set; }
        public string data_value_12 { get; set; }
        public string data_value_13 { get; set; }
        public string data_value_14 { get; set; }
        public string data_value_15 { get; set; }
        public string data_value_16 { get; set; }
        public string data_value_17 { get; set; }
        public string data_value_18 { get; set; }
        public string data_value_19 { get; set; }
        public string data_value_20 { get; set; }
        public string data_value_21 { get; set; }
        public string data_value_22 { get; set; }
        public string data_value_23 { get; set; }
        public string data_value_24 { get; set; }
        public string data_value_25 { get; set; }
        public string data_value_26 { get; set; }
        public string data_value_27 { get; set; }
        public string data_value_28 { get; set; }
        public string data_value_29 { get; set; }
        public string data_value_30 { get; set; }
        public string data_value_31 { get; set; }
        public string data_value_32 { get; set; }
        public string data_value_33 { get; set; }
        public string data_value_34 { get; set; }
        public string data_value_35 { get; set; }
        public string data_value_36 { get; set; }
        public string data_value_37 { get; set; }
        public string data_value_38 { get; set; }
        public string data_value_39 { get; set; }
        public string data_value_40 { get; set; }
        public DateTime clm_date_time { get; set; }
        public string clm_user { get; set; }

    }
    public class IOT_DEVICE_EDC_075
    {

        public int id { get; set; }
        public string device_id { get; set; }
        public string data_value_01 { get; set; }
        public string data_value_02 { get; set; }
        public string data_value_03 { get; set; }
        public string data_value_04 { get; set; }
        public string data_value_05 { get; set; }
        public string data_value_06 { get; set; }
        public string data_value_07 { get; set; }
        public string data_value_08 { get; set; }
        public string data_value_09 { get; set; }
        public string data_value_10 { get; set; }
        public string data_value_11 { get; set; }
        public string data_value_12 { get; set; }
        public string data_value_13 { get; set; }
        public string data_value_14 { get; set; }
        public string data_value_15 { get; set; }
        public string data_value_16 { get; set; }
        public string data_value_17 { get; set; }
        public string data_value_18 { get; set; }
        public string data_value_19 { get; set; }
        public string data_value_20 { get; set; }
        public string data_value_21 { get; set; }
        public string data_value_22 { get; set; }
        public string data_value_23 { get; set; }
        public string data_value_24 { get; set; }
        public string data_value_25 { get; set; }
        public string data_value_26 { get; set; }
        public string data_value_27 { get; set; }
        public string data_value_28 { get; set; }
        public string data_value_29 { get; set; }
        public string data_value_30 { get; set; }
        public string data_value_31 { get; set; }
        public string data_value_32 { get; set; }
        public string data_value_33 { get; set; }
        public string data_value_34 { get; set; }
        public string data_value_35 { get; set; }
        public string data_value_36 { get; set; }
        public string data_value_37 { get; set; }
        public string data_value_38 { get; set; }
        public string data_value_39 { get; set; }
        public string data_value_40 { get; set; }
        public DateTime clm_date_time { get; set; }
        public string clm_user { get; set; }

    }
    public class IOT_DEVICE_EDC_076
    {

        public int id { get; set; }
        public string device_id { get; set; }
        public string data_value_01 { get; set; }
        public string data_value_02 { get; set; }
        public string data_value_03 { get; set; }
        public string data_value_04 { get; set; }
        public string data_value_05 { get; set; }
        public string data_value_06 { get; set; }
        public string data_value_07 { get; set; }
        public string data_value_08 { get; set; }
        public string data_value_09 { get; set; }
        public string data_value_10 { get; set; }
        public string data_value_11 { get; set; }
        public string data_value_12 { get; set; }
        public string data_value_13 { get; set; }
        public string data_value_14 { get; set; }
        public string data_value_15 { get; set; }
        public string data_value_16 { get; set; }
        public string data_value_17 { get; set; }
        public string data_value_18 { get; set; }
        public string data_value_19 { get; set; }
        public string data_value_20 { get; set; }
        public string data_value_21 { get; set; }
        public string data_value_22 { get; set; }
        public string data_value_23 { get; set; }
        public string data_value_24 { get; set; }
        public string data_value_25 { get; set; }
        public string data_value_26 { get; set; }
        public string data_value_27 { get; set; }
        public string data_value_28 { get; set; }
        public string data_value_29 { get; set; }
        public string data_value_30 { get; set; }
        public string data_value_31 { get; set; }
        public string data_value_32 { get; set; }
        public string data_value_33 { get; set; }
        public string data_value_34 { get; set; }
        public string data_value_35 { get; set; }
        public string data_value_36 { get; set; }
        public string data_value_37 { get; set; }
        public string data_value_38 { get; set; }
        public string data_value_39 { get; set; }
        public string data_value_40 { get; set; }
        public DateTime clm_date_time { get; set; }
        public string clm_user { get; set; }

    }
    public class IOT_DEVICE_EDC_077
    {

        public int id { get; set; }
        public string device_id { get; set; }
        public string data_value_01 { get; set; }
        public string data_value_02 { get; set; }
        public string data_value_03 { get; set; }
        public string data_value_04 { get; set; }
        public string data_value_05 { get; set; }
        public string data_value_06 { get; set; }
        public string data_value_07 { get; set; }
        public string data_value_08 { get; set; }
        public string data_value_09 { get; set; }
        public string data_value_10 { get; set; }
        public string data_value_11 { get; set; }
        public string data_value_12 { get; set; }
        public string data_value_13 { get; set; }
        public string data_value_14 { get; set; }
        public string data_value_15 { get; set; }
        public string data_value_16 { get; set; }
        public string data_value_17 { get; set; }
        public string data_value_18 { get; set; }
        public string data_value_19 { get; set; }
        public string data_value_20 { get; set; }
        public string data_value_21 { get; set; }
        public string data_value_22 { get; set; }
        public string data_value_23 { get; set; }
        public string data_value_24 { get; set; }
        public string data_value_25 { get; set; }
        public string data_value_26 { get; set; }
        public string data_value_27 { get; set; }
        public string data_value_28 { get; set; }
        public string data_value_29 { get; set; }
        public string data_value_30 { get; set; }
        public string data_value_31 { get; set; }
        public string data_value_32 { get; set; }
        public string data_value_33 { get; set; }
        public string data_value_34 { get; set; }
        public string data_value_35 { get; set; }
        public string data_value_36 { get; set; }
        public string data_value_37 { get; set; }
        public string data_value_38 { get; set; }
        public string data_value_39 { get; set; }
        public string data_value_40 { get; set; }
        public DateTime clm_date_time { get; set; }
        public string clm_user { get; set; }

    }
    public class IOT_DEVICE_EDC_078
    {

        public int id { get; set; }
        public string device_id { get; set; }
        public string data_value_01 { get; set; }
        public string data_value_02 { get; set; }
        public string data_value_03 { get; set; }
        public string data_value_04 { get; set; }
        public string data_value_05 { get; set; }
        public string data_value_06 { get; set; }
        public string data_value_07 { get; set; }
        public string data_value_08 { get; set; }
        public string data_value_09 { get; set; }
        public string data_value_10 { get; set; }
        public string data_value_11 { get; set; }
        public string data_value_12 { get; set; }
        public string data_value_13 { get; set; }
        public string data_value_14 { get; set; }
        public string data_value_15 { get; set; }
        public string data_value_16 { get; set; }
        public string data_value_17 { get; set; }
        public string data_value_18 { get; set; }
        public string data_value_19 { get; set; }
        public string data_value_20 { get; set; }
        public string data_value_21 { get; set; }
        public string data_value_22 { get; set; }
        public string data_value_23 { get; set; }
        public string data_value_24 { get; set; }
        public string data_value_25 { get; set; }
        public string data_value_26 { get; set; }
        public string data_value_27 { get; set; }
        public string data_value_28 { get; set; }
        public string data_value_29 { get; set; }
        public string data_value_30 { get; set; }
        public string data_value_31 { get; set; }
        public string data_value_32 { get; set; }
        public string data_value_33 { get; set; }
        public string data_value_34 { get; set; }
        public string data_value_35 { get; set; }
        public string data_value_36 { get; set; }
        public string data_value_37 { get; set; }
        public string data_value_38 { get; set; }
        public string data_value_39 { get; set; }
        public string data_value_40 { get; set; }
        public DateTime clm_date_time { get; set; }
        public string clm_user { get; set; }

    }
    public class IOT_DEVICE_EDC_079
    {

        public int id { get; set; }
        public string device_id { get; set; }
        public string data_value_01 { get; set; }
        public string data_value_02 { get; set; }
        public string data_value_03 { get; set; }
        public string data_value_04 { get; set; }
        public string data_value_05 { get; set; }
        public string data_value_06 { get; set; }
        public string data_value_07 { get; set; }
        public string data_value_08 { get; set; }
        public string data_value_09 { get; set; }
        public string data_value_10 { get; set; }
        public string data_value_11 { get; set; }
        public string data_value_12 { get; set; }
        public string data_value_13 { get; set; }
        public string data_value_14 { get; set; }
        public string data_value_15 { get; set; }
        public string data_value_16 { get; set; }
        public string data_value_17 { get; set; }
        public string data_value_18 { get; set; }
        public string data_value_19 { get; set; }
        public string data_value_20 { get; set; }
        public string data_value_21 { get; set; }
        public string data_value_22 { get; set; }
        public string data_value_23 { get; set; }
        public string data_value_24 { get; set; }
        public string data_value_25 { get; set; }
        public string data_value_26 { get; set; }
        public string data_value_27 { get; set; }
        public string data_value_28 { get; set; }
        public string data_value_29 { get; set; }
        public string data_value_30 { get; set; }
        public string data_value_31 { get; set; }
        public string data_value_32 { get; set; }
        public string data_value_33 { get; set; }
        public string data_value_34 { get; set; }
        public string data_value_35 { get; set; }
        public string data_value_36 { get; set; }
        public string data_value_37 { get; set; }
        public string data_value_38 { get; set; }
        public string data_value_39 { get; set; }
        public string data_value_40 { get; set; }
        public DateTime clm_date_time { get; set; }
        public string clm_user { get; set; }

    }
    public class IOT_DEVICE_EDC_080
    {

        public int id { get; set; }
        public string device_id { get; set; }
        public string data_value_01 { get; set; }
        public string data_value_02 { get; set; }
        public string data_value_03 { get; set; }
        public string data_value_04 { get; set; }
        public string data_value_05 { get; set; }
        public string data_value_06 { get; set; }
        public string data_value_07 { get; set; }
        public string data_value_08 { get; set; }
        public string data_value_09 { get; set; }
        public string data_value_10 { get; set; }
        public string data_value_11 { get; set; }
        public string data_value_12 { get; set; }
        public string data_value_13 { get; set; }
        public string data_value_14 { get; set; }
        public string data_value_15 { get; set; }
        public string data_value_16 { get; set; }
        public string data_value_17 { get; set; }
        public string data_value_18 { get; set; }
        public string data_value_19 { get; set; }
        public string data_value_20 { get; set; }
        public string data_value_21 { get; set; }
        public string data_value_22 { get; set; }
        public string data_value_23 { get; set; }
        public string data_value_24 { get; set; }
        public string data_value_25 { get; set; }
        public string data_value_26 { get; set; }
        public string data_value_27 { get; set; }
        public string data_value_28 { get; set; }
        public string data_value_29 { get; set; }
        public string data_value_30 { get; set; }
        public string data_value_31 { get; set; }
        public string data_value_32 { get; set; }
        public string data_value_33 { get; set; }
        public string data_value_34 { get; set; }
        public string data_value_35 { get; set; }
        public string data_value_36 { get; set; }
        public string data_value_37 { get; set; }
        public string data_value_38 { get; set; }
        public string data_value_39 { get; set; }
        public string data_value_40 { get; set; }
        public DateTime clm_date_time { get; set; }
        public string clm_user { get; set; }

    }
    public class IOT_DEVICE_EDC_081
    {

        public int id { get; set; }
        public string device_id { get; set; }
        public string data_value_01 { get; set; }
        public string data_value_02 { get; set; }
        public string data_value_03 { get; set; }
        public string data_value_04 { get; set; }
        public string data_value_05 { get; set; }
        public string data_value_06 { get; set; }
        public string data_value_07 { get; set; }
        public string data_value_08 { get; set; }
        public string data_value_09 { get; set; }
        public string data_value_10 { get; set; }
        public string data_value_11 { get; set; }
        public string data_value_12 { get; set; }
        public string data_value_13 { get; set; }
        public string data_value_14 { get; set; }
        public string data_value_15 { get; set; }
        public string data_value_16 { get; set; }
        public string data_value_17 { get; set; }
        public string data_value_18 { get; set; }
        public string data_value_19 { get; set; }
        public string data_value_20 { get; set; }
        public string data_value_21 { get; set; }
        public string data_value_22 { get; set; }
        public string data_value_23 { get; set; }
        public string data_value_24 { get; set; }
        public string data_value_25 { get; set; }
        public string data_value_26 { get; set; }
        public string data_value_27 { get; set; }
        public string data_value_28 { get; set; }
        public string data_value_29 { get; set; }
        public string data_value_30 { get; set; }
        public string data_value_31 { get; set; }
        public string data_value_32 { get; set; }
        public string data_value_33 { get; set; }
        public string data_value_34 { get; set; }
        public string data_value_35 { get; set; }
        public string data_value_36 { get; set; }
        public string data_value_37 { get; set; }
        public string data_value_38 { get; set; }
        public string data_value_39 { get; set; }
        public string data_value_40 { get; set; }
        public DateTime clm_date_time { get; set; }
        public string clm_user { get; set; }

    }
    public class IOT_DEVICE_EDC_082
    {

        public int id { get; set; }
        public string device_id { get; set; }
        public string data_value_01 { get; set; }
        public string data_value_02 { get; set; }
        public string data_value_03 { get; set; }
        public string data_value_04 { get; set; }
        public string data_value_05 { get; set; }
        public string data_value_06 { get; set; }
        public string data_value_07 { get; set; }
        public string data_value_08 { get; set; }
        public string data_value_09 { get; set; }
        public string data_value_10 { get; set; }
        public string data_value_11 { get; set; }
        public string data_value_12 { get; set; }
        public string data_value_13 { get; set; }
        public string data_value_14 { get; set; }
        public string data_value_15 { get; set; }
        public string data_value_16 { get; set; }
        public string data_value_17 { get; set; }
        public string data_value_18 { get; set; }
        public string data_value_19 { get; set; }
        public string data_value_20 { get; set; }
        public string data_value_21 { get; set; }
        public string data_value_22 { get; set; }
        public string data_value_23 { get; set; }
        public string data_value_24 { get; set; }
        public string data_value_25 { get; set; }
        public string data_value_26 { get; set; }
        public string data_value_27 { get; set; }
        public string data_value_28 { get; set; }
        public string data_value_29 { get; set; }
        public string data_value_30 { get; set; }
        public string data_value_31 { get; set; }
        public string data_value_32 { get; set; }
        public string data_value_33 { get; set; }
        public string data_value_34 { get; set; }
        public string data_value_35 { get; set; }
        public string data_value_36 { get; set; }
        public string data_value_37 { get; set; }
        public string data_value_38 { get; set; }
        public string data_value_39 { get; set; }
        public string data_value_40 { get; set; }
        public DateTime clm_date_time { get; set; }
        public string clm_user { get; set; }

    }
    public class IOT_DEVICE_EDC_083
    {

        public int id { get; set; }
        public string device_id { get; set; }
        public string data_value_01 { get; set; }
        public string data_value_02 { get; set; }
        public string data_value_03 { get; set; }
        public string data_value_04 { get; set; }
        public string data_value_05 { get; set; }
        public string data_value_06 { get; set; }
        public string data_value_07 { get; set; }
        public string data_value_08 { get; set; }
        public string data_value_09 { get; set; }
        public string data_value_10 { get; set; }
        public string data_value_11 { get; set; }
        public string data_value_12 { get; set; }
        public string data_value_13 { get; set; }
        public string data_value_14 { get; set; }
        public string data_value_15 { get; set; }
        public string data_value_16 { get; set; }
        public string data_value_17 { get; set; }
        public string data_value_18 { get; set; }
        public string data_value_19 { get; set; }
        public string data_value_20 { get; set; }
        public string data_value_21 { get; set; }
        public string data_value_22 { get; set; }
        public string data_value_23 { get; set; }
        public string data_value_24 { get; set; }
        public string data_value_25 { get; set; }
        public string data_value_26 { get; set; }
        public string data_value_27 { get; set; }
        public string data_value_28 { get; set; }
        public string data_value_29 { get; set; }
        public string data_value_30 { get; set; }
        public string data_value_31 { get; set; }
        public string data_value_32 { get; set; }
        public string data_value_33 { get; set; }
        public string data_value_34 { get; set; }
        public string data_value_35 { get; set; }
        public string data_value_36 { get; set; }
        public string data_value_37 { get; set; }
        public string data_value_38 { get; set; }
        public string data_value_39 { get; set; }
        public string data_value_40 { get; set; }
        public DateTime clm_date_time { get; set; }
        public string clm_user { get; set; }

    }
    public class IOT_DEVICE_EDC_084
    {

        public int id { get; set; }
        public string device_id { get; set; }
        public string data_value_01 { get; set; }
        public string data_value_02 { get; set; }
        public string data_value_03 { get; set; }
        public string data_value_04 { get; set; }
        public string data_value_05 { get; set; }
        public string data_value_06 { get; set; }
        public string data_value_07 { get; set; }
        public string data_value_08 { get; set; }
        public string data_value_09 { get; set; }
        public string data_value_10 { get; set; }
        public string data_value_11 { get; set; }
        public string data_value_12 { get; set; }
        public string data_value_13 { get; set; }
        public string data_value_14 { get; set; }
        public string data_value_15 { get; set; }
        public string data_value_16 { get; set; }
        public string data_value_17 { get; set; }
        public string data_value_18 { get; set; }
        public string data_value_19 { get; set; }
        public string data_value_20 { get; set; }
        public string data_value_21 { get; set; }
        public string data_value_22 { get; set; }
        public string data_value_23 { get; set; }
        public string data_value_24 { get; set; }
        public string data_value_25 { get; set; }
        public string data_value_26 { get; set; }
        public string data_value_27 { get; set; }
        public string data_value_28 { get; set; }
        public string data_value_29 { get; set; }
        public string data_value_30 { get; set; }
        public string data_value_31 { get; set; }
        public string data_value_32 { get; set; }
        public string data_value_33 { get; set; }
        public string data_value_34 { get; set; }
        public string data_value_35 { get; set; }
        public string data_value_36 { get; set; }
        public string data_value_37 { get; set; }
        public string data_value_38 { get; set; }
        public string data_value_39 { get; set; }
        public string data_value_40 { get; set; }
        public DateTime clm_date_time { get; set; }
        public string clm_user { get; set; }

    }
    public class IOT_DEVICE_EDC_085
    {

        public int id { get; set; }
        public string device_id { get; set; }
        public string data_value_01 { get; set; }
        public string data_value_02 { get; set; }
        public string data_value_03 { get; set; }
        public string data_value_04 { get; set; }
        public string data_value_05 { get; set; }
        public string data_value_06 { get; set; }
        public string data_value_07 { get; set; }
        public string data_value_08 { get; set; }
        public string data_value_09 { get; set; }
        public string data_value_10 { get; set; }
        public string data_value_11 { get; set; }
        public string data_value_12 { get; set; }
        public string data_value_13 { get; set; }
        public string data_value_14 { get; set; }
        public string data_value_15 { get; set; }
        public string data_value_16 { get; set; }
        public string data_value_17 { get; set; }
        public string data_value_18 { get; set; }
        public string data_value_19 { get; set; }
        public string data_value_20 { get; set; }
        public string data_value_21 { get; set; }
        public string data_value_22 { get; set; }
        public string data_value_23 { get; set; }
        public string data_value_24 { get; set; }
        public string data_value_25 { get; set; }
        public string data_value_26 { get; set; }
        public string data_value_27 { get; set; }
        public string data_value_28 { get; set; }
        public string data_value_29 { get; set; }
        public string data_value_30 { get; set; }
        public string data_value_31 { get; set; }
        public string data_value_32 { get; set; }
        public string data_value_33 { get; set; }
        public string data_value_34 { get; set; }
        public string data_value_35 { get; set; }
        public string data_value_36 { get; set; }
        public string data_value_37 { get; set; }
        public string data_value_38 { get; set; }
        public string data_value_39 { get; set; }
        public string data_value_40 { get; set; }
        public DateTime clm_date_time { get; set; }
        public string clm_user { get; set; }

    }
    public class IOT_DEVICE_EDC_086
    {

        public int id { get; set; }
        public string device_id { get; set; }
        public string data_value_01 { get; set; }
        public string data_value_02 { get; set; }
        public string data_value_03 { get; set; }
        public string data_value_04 { get; set; }
        public string data_value_05 { get; set; }
        public string data_value_06 { get; set; }
        public string data_value_07 { get; set; }
        public string data_value_08 { get; set; }
        public string data_value_09 { get; set; }
        public string data_value_10 { get; set; }
        public string data_value_11 { get; set; }
        public string data_value_12 { get; set; }
        public string data_value_13 { get; set; }
        public string data_value_14 { get; set; }
        public string data_value_15 { get; set; }
        public string data_value_16 { get; set; }
        public string data_value_17 { get; set; }
        public string data_value_18 { get; set; }
        public string data_value_19 { get; set; }
        public string data_value_20 { get; set; }
        public string data_value_21 { get; set; }
        public string data_value_22 { get; set; }
        public string data_value_23 { get; set; }
        public string data_value_24 { get; set; }
        public string data_value_25 { get; set; }
        public string data_value_26 { get; set; }
        public string data_value_27 { get; set; }
        public string data_value_28 { get; set; }
        public string data_value_29 { get; set; }
        public string data_value_30 { get; set; }
        public string data_value_31 { get; set; }
        public string data_value_32 { get; set; }
        public string data_value_33 { get; set; }
        public string data_value_34 { get; set; }
        public string data_value_35 { get; set; }
        public string data_value_36 { get; set; }
        public string data_value_37 { get; set; }
        public string data_value_38 { get; set; }
        public string data_value_39 { get; set; }
        public string data_value_40 { get; set; }
        public DateTime clm_date_time { get; set; }
        public string clm_user { get; set; }

    }
    public class IOT_DEVICE_EDC_087
    {

        public int id { get; set; }
        public string device_id { get; set; }
        public string data_value_01 { get; set; }
        public string data_value_02 { get; set; }
        public string data_value_03 { get; set; }
        public string data_value_04 { get; set; }
        public string data_value_05 { get; set; }
        public string data_value_06 { get; set; }
        public string data_value_07 { get; set; }
        public string data_value_08 { get; set; }
        public string data_value_09 { get; set; }
        public string data_value_10 { get; set; }
        public string data_value_11 { get; set; }
        public string data_value_12 { get; set; }
        public string data_value_13 { get; set; }
        public string data_value_14 { get; set; }
        public string data_value_15 { get; set; }
        public string data_value_16 { get; set; }
        public string data_value_17 { get; set; }
        public string data_value_18 { get; set; }
        public string data_value_19 { get; set; }
        public string data_value_20 { get; set; }
        public string data_value_21 { get; set; }
        public string data_value_22 { get; set; }
        public string data_value_23 { get; set; }
        public string data_value_24 { get; set; }
        public string data_value_25 { get; set; }
        public string data_value_26 { get; set; }
        public string data_value_27 { get; set; }
        public string data_value_28 { get; set; }
        public string data_value_29 { get; set; }
        public string data_value_30 { get; set; }
        public string data_value_31 { get; set; }
        public string data_value_32 { get; set; }
        public string data_value_33 { get; set; }
        public string data_value_34 { get; set; }
        public string data_value_35 { get; set; }
        public string data_value_36 { get; set; }
        public string data_value_37 { get; set; }
        public string data_value_38 { get; set; }
        public string data_value_39 { get; set; }
        public string data_value_40 { get; set; }
        public DateTime clm_date_time { get; set; }
        public string clm_user { get; set; }

    }
    public class IOT_DEVICE_EDC_088
    {

        public int id { get; set; }
        public string device_id { get; set; }
        public string data_value_01 { get; set; }
        public string data_value_02 { get; set; }
        public string data_value_03 { get; set; }
        public string data_value_04 { get; set; }
        public string data_value_05 { get; set; }
        public string data_value_06 { get; set; }
        public string data_value_07 { get; set; }
        public string data_value_08 { get; set; }
        public string data_value_09 { get; set; }
        public string data_value_10 { get; set; }
        public string data_value_11 { get; set; }
        public string data_value_12 { get; set; }
        public string data_value_13 { get; set; }
        public string data_value_14 { get; set; }
        public string data_value_15 { get; set; }
        public string data_value_16 { get; set; }
        public string data_value_17 { get; set; }
        public string data_value_18 { get; set; }
        public string data_value_19 { get; set; }
        public string data_value_20 { get; set; }
        public string data_value_21 { get; set; }
        public string data_value_22 { get; set; }
        public string data_value_23 { get; set; }
        public string data_value_24 { get; set; }
        public string data_value_25 { get; set; }
        public string data_value_26 { get; set; }
        public string data_value_27 { get; set; }
        public string data_value_28 { get; set; }
        public string data_value_29 { get; set; }
        public string data_value_30 { get; set; }
        public string data_value_31 { get; set; }
        public string data_value_32 { get; set; }
        public string data_value_33 { get; set; }
        public string data_value_34 { get; set; }
        public string data_value_35 { get; set; }
        public string data_value_36 { get; set; }
        public string data_value_37 { get; set; }
        public string data_value_38 { get; set; }
        public string data_value_39 { get; set; }
        public string data_value_40 { get; set; }
        public DateTime clm_date_time { get; set; }
        public string clm_user { get; set; }

    }
    public class IOT_DEVICE_EDC_089
    {

        public int id { get; set; }
        public string device_id { get; set; }
        public string data_value_01 { get; set; }
        public string data_value_02 { get; set; }
        public string data_value_03 { get; set; }
        public string data_value_04 { get; set; }
        public string data_value_05 { get; set; }
        public string data_value_06 { get; set; }
        public string data_value_07 { get; set; }
        public string data_value_08 { get; set; }
        public string data_value_09 { get; set; }
        public string data_value_10 { get; set; }
        public string data_value_11 { get; set; }
        public string data_value_12 { get; set; }
        public string data_value_13 { get; set; }
        public string data_value_14 { get; set; }
        public string data_value_15 { get; set; }
        public string data_value_16 { get; set; }
        public string data_value_17 { get; set; }
        public string data_value_18 { get; set; }
        public string data_value_19 { get; set; }
        public string data_value_20 { get; set; }
        public string data_value_21 { get; set; }
        public string data_value_22 { get; set; }
        public string data_value_23 { get; set; }
        public string data_value_24 { get; set; }
        public string data_value_25 { get; set; }
        public string data_value_26 { get; set; }
        public string data_value_27 { get; set; }
        public string data_value_28 { get; set; }
        public string data_value_29 { get; set; }
        public string data_value_30 { get; set; }
        public string data_value_31 { get; set; }
        public string data_value_32 { get; set; }
        public string data_value_33 { get; set; }
        public string data_value_34 { get; set; }
        public string data_value_35 { get; set; }
        public string data_value_36 { get; set; }
        public string data_value_37 { get; set; }
        public string data_value_38 { get; set; }
        public string data_value_39 { get; set; }
        public string data_value_40 { get; set; }
        public DateTime clm_date_time { get; set; }
        public string clm_user { get; set; }

    }
    public class IOT_DEVICE_EDC_090
    {

        public int id { get; set; }
        public string device_id { get; set; }
        public string data_value_01 { get; set; }
        public string data_value_02 { get; set; }
        public string data_value_03 { get; set; }
        public string data_value_04 { get; set; }
        public string data_value_05 { get; set; }
        public string data_value_06 { get; set; }
        public string data_value_07 { get; set; }
        public string data_value_08 { get; set; }
        public string data_value_09 { get; set; }
        public string data_value_10 { get; set; }
        public string data_value_11 { get; set; }
        public string data_value_12 { get; set; }
        public string data_value_13 { get; set; }
        public string data_value_14 { get; set; }
        public string data_value_15 { get; set; }
        public string data_value_16 { get; set; }
        public string data_value_17 { get; set; }
        public string data_value_18 { get; set; }
        public string data_value_19 { get; set; }
        public string data_value_20 { get; set; }
        public string data_value_21 { get; set; }
        public string data_value_22 { get; set; }
        public string data_value_23 { get; set; }
        public string data_value_24 { get; set; }
        public string data_value_25 { get; set; }
        public string data_value_26 { get; set; }
        public string data_value_27 { get; set; }
        public string data_value_28 { get; set; }
        public string data_value_29 { get; set; }
        public string data_value_30 { get; set; }
        public string data_value_31 { get; set; }
        public string data_value_32 { get; set; }
        public string data_value_33 { get; set; }
        public string data_value_34 { get; set; }
        public string data_value_35 { get; set; }
        public string data_value_36 { get; set; }
        public string data_value_37 { get; set; }
        public string data_value_38 { get; set; }
        public string data_value_39 { get; set; }
        public string data_value_40 { get; set; }
        public DateTime clm_date_time { get; set; }
        public string clm_user { get; set; }

    }
    public class IOT_DEVICE_EDC_091
    {

        public int id { get; set; }
        public string device_id { get; set; }
        public string data_value_01 { get; set; }
        public string data_value_02 { get; set; }
        public string data_value_03 { get; set; }
        public string data_value_04 { get; set; }
        public string data_value_05 { get; set; }
        public string data_value_06 { get; set; }
        public string data_value_07 { get; set; }
        public string data_value_08 { get; set; }
        public string data_value_09 { get; set; }
        public string data_value_10 { get; set; }
        public string data_value_11 { get; set; }
        public string data_value_12 { get; set; }
        public string data_value_13 { get; set; }
        public string data_value_14 { get; set; }
        public string data_value_15 { get; set; }
        public string data_value_16 { get; set; }
        public string data_value_17 { get; set; }
        public string data_value_18 { get; set; }
        public string data_value_19 { get; set; }
        public string data_value_20 { get; set; }
        public string data_value_21 { get; set; }
        public string data_value_22 { get; set; }
        public string data_value_23 { get; set; }
        public string data_value_24 { get; set; }
        public string data_value_25 { get; set; }
        public string data_value_26 { get; set; }
        public string data_value_27 { get; set; }
        public string data_value_28 { get; set; }
        public string data_value_29 { get; set; }
        public string data_value_30 { get; set; }
        public string data_value_31 { get; set; }
        public string data_value_32 { get; set; }
        public string data_value_33 { get; set; }
        public string data_value_34 { get; set; }
        public string data_value_35 { get; set; }
        public string data_value_36 { get; set; }
        public string data_value_37 { get; set; }
        public string data_value_38 { get; set; }
        public string data_value_39 { get; set; }
        public string data_value_40 { get; set; }
        public DateTime clm_date_time { get; set; }
        public string clm_user { get; set; }

    }
    public class IOT_DEVICE_EDC_092
    {

        public int id { get; set; }
        public string device_id { get; set; }
        public string data_value_01 { get; set; }
        public string data_value_02 { get; set; }
        public string data_value_03 { get; set; }
        public string data_value_04 { get; set; }
        public string data_value_05 { get; set; }
        public string data_value_06 { get; set; }
        public string data_value_07 { get; set; }
        public string data_value_08 { get; set; }
        public string data_value_09 { get; set; }
        public string data_value_10 { get; set; }
        public string data_value_11 { get; set; }
        public string data_value_12 { get; set; }
        public string data_value_13 { get; set; }
        public string data_value_14 { get; set; }
        public string data_value_15 { get; set; }
        public string data_value_16 { get; set; }
        public string data_value_17 { get; set; }
        public string data_value_18 { get; set; }
        public string data_value_19 { get; set; }
        public string data_value_20 { get; set; }
        public string data_value_21 { get; set; }
        public string data_value_22 { get; set; }
        public string data_value_23 { get; set; }
        public string data_value_24 { get; set; }
        public string data_value_25 { get; set; }
        public string data_value_26 { get; set; }
        public string data_value_27 { get; set; }
        public string data_value_28 { get; set; }
        public string data_value_29 { get; set; }
        public string data_value_30 { get; set; }
        public string data_value_31 { get; set; }
        public string data_value_32 { get; set; }
        public string data_value_33 { get; set; }
        public string data_value_34 { get; set; }
        public string data_value_35 { get; set; }
        public string data_value_36 { get; set; }
        public string data_value_37 { get; set; }
        public string data_value_38 { get; set; }
        public string data_value_39 { get; set; }
        public string data_value_40 { get; set; }
        public DateTime clm_date_time { get; set; }
        public string clm_user { get; set; }

    }
    public class IOT_DEVICE_EDC_093
    {

        public int id { get; set; }
        public string device_id { get; set; }
        public string data_value_01 { get; set; }
        public string data_value_02 { get; set; }
        public string data_value_03 { get; set; }
        public string data_value_04 { get; set; }
        public string data_value_05 { get; set; }
        public string data_value_06 { get; set; }
        public string data_value_07 { get; set; }
        public string data_value_08 { get; set; }
        public string data_value_09 { get; set; }
        public string data_value_10 { get; set; }
        public string data_value_11 { get; set; }
        public string data_value_12 { get; set; }
        public string data_value_13 { get; set; }
        public string data_value_14 { get; set; }
        public string data_value_15 { get; set; }
        public string data_value_16 { get; set; }
        public string data_value_17 { get; set; }
        public string data_value_18 { get; set; }
        public string data_value_19 { get; set; }
        public string data_value_20 { get; set; }
        public string data_value_21 { get; set; }
        public string data_value_22 { get; set; }
        public string data_value_23 { get; set; }
        public string data_value_24 { get; set; }
        public string data_value_25 { get; set; }
        public string data_value_26 { get; set; }
        public string data_value_27 { get; set; }
        public string data_value_28 { get; set; }
        public string data_value_29 { get; set; }
        public string data_value_30 { get; set; }
        public string data_value_31 { get; set; }
        public string data_value_32 { get; set; }
        public string data_value_33 { get; set; }
        public string data_value_34 { get; set; }
        public string data_value_35 { get; set; }
        public string data_value_36 { get; set; }
        public string data_value_37 { get; set; }
        public string data_value_38 { get; set; }
        public string data_value_39 { get; set; }
        public string data_value_40 { get; set; }
        public DateTime clm_date_time { get; set; }
        public string clm_user { get; set; }

    }
    public class IOT_DEVICE_EDC_094
    {

        public int id { get; set; }
        public string device_id { get; set; }
        public string data_value_01 { get; set; }
        public string data_value_02 { get; set; }
        public string data_value_03 { get; set; }
        public string data_value_04 { get; set; }
        public string data_value_05 { get; set; }
        public string data_value_06 { get; set; }
        public string data_value_07 { get; set; }
        public string data_value_08 { get; set; }
        public string data_value_09 { get; set; }
        public string data_value_10 { get; set; }
        public string data_value_11 { get; set; }
        public string data_value_12 { get; set; }
        public string data_value_13 { get; set; }
        public string data_value_14 { get; set; }
        public string data_value_15 { get; set; }
        public string data_value_16 { get; set; }
        public string data_value_17 { get; set; }
        public string data_value_18 { get; set; }
        public string data_value_19 { get; set; }
        public string data_value_20 { get; set; }
        public string data_value_21 { get; set; }
        public string data_value_22 { get; set; }
        public string data_value_23 { get; set; }
        public string data_value_24 { get; set; }
        public string data_value_25 { get; set; }
        public string data_value_26 { get; set; }
        public string data_value_27 { get; set; }
        public string data_value_28 { get; set; }
        public string data_value_29 { get; set; }
        public string data_value_30 { get; set; }
        public string data_value_31 { get; set; }
        public string data_value_32 { get; set; }
        public string data_value_33 { get; set; }
        public string data_value_34 { get; set; }
        public string data_value_35 { get; set; }
        public string data_value_36 { get; set; }
        public string data_value_37 { get; set; }
        public string data_value_38 { get; set; }
        public string data_value_39 { get; set; }
        public string data_value_40 { get; set; }
        public DateTime clm_date_time { get; set; }
        public string clm_user { get; set; }

    }
    public class IOT_DEVICE_EDC_095
    {

        public int id { get; set; }
        public string device_id { get; set; }
        public string data_value_01 { get; set; }
        public string data_value_02 { get; set; }
        public string data_value_03 { get; set; }
        public string data_value_04 { get; set; }
        public string data_value_05 { get; set; }
        public string data_value_06 { get; set; }
        public string data_value_07 { get; set; }
        public string data_value_08 { get; set; }
        public string data_value_09 { get; set; }
        public string data_value_10 { get; set; }
        public string data_value_11 { get; set; }
        public string data_value_12 { get; set; }
        public string data_value_13 { get; set; }
        public string data_value_14 { get; set; }
        public string data_value_15 { get; set; }
        public string data_value_16 { get; set; }
        public string data_value_17 { get; set; }
        public string data_value_18 { get; set; }
        public string data_value_19 { get; set; }
        public string data_value_20 { get; set; }
        public string data_value_21 { get; set; }
        public string data_value_22 { get; set; }
        public string data_value_23 { get; set; }
        public string data_value_24 { get; set; }
        public string data_value_25 { get; set; }
        public string data_value_26 { get; set; }
        public string data_value_27 { get; set; }
        public string data_value_28 { get; set; }
        public string data_value_29 { get; set; }
        public string data_value_30 { get; set; }
        public string data_value_31 { get; set; }
        public string data_value_32 { get; set; }
        public string data_value_33 { get; set; }
        public string data_value_34 { get; set; }
        public string data_value_35 { get; set; }
        public string data_value_36 { get; set; }
        public string data_value_37 { get; set; }
        public string data_value_38 { get; set; }
        public string data_value_39 { get; set; }
        public string data_value_40 { get; set; }
        public DateTime clm_date_time { get; set; }
        public string clm_user { get; set; }

    }
    public class IOT_DEVICE_EDC_096
    {

        public int id { get; set; }
        public string device_id { get; set; }
        public string data_value_01 { get; set; }
        public string data_value_02 { get; set; }
        public string data_value_03 { get; set; }
        public string data_value_04 { get; set; }
        public string data_value_05 { get; set; }
        public string data_value_06 { get; set; }
        public string data_value_07 { get; set; }
        public string data_value_08 { get; set; }
        public string data_value_09 { get; set; }
        public string data_value_10 { get; set; }
        public string data_value_11 { get; set; }
        public string data_value_12 { get; set; }
        public string data_value_13 { get; set; }
        public string data_value_14 { get; set; }
        public string data_value_15 { get; set; }
        public string data_value_16 { get; set; }
        public string data_value_17 { get; set; }
        public string data_value_18 { get; set; }
        public string data_value_19 { get; set; }
        public string data_value_20 { get; set; }
        public string data_value_21 { get; set; }
        public string data_value_22 { get; set; }
        public string data_value_23 { get; set; }
        public string data_value_24 { get; set; }
        public string data_value_25 { get; set; }
        public string data_value_26 { get; set; }
        public string data_value_27 { get; set; }
        public string data_value_28 { get; set; }
        public string data_value_29 { get; set; }
        public string data_value_30 { get; set; }
        public string data_value_31 { get; set; }
        public string data_value_32 { get; set; }
        public string data_value_33 { get; set; }
        public string data_value_34 { get; set; }
        public string data_value_35 { get; set; }
        public string data_value_36 { get; set; }
        public string data_value_37 { get; set; }
        public string data_value_38 { get; set; }
        public string data_value_39 { get; set; }
        public string data_value_40 { get; set; }
        public DateTime clm_date_time { get; set; }
        public string clm_user { get; set; }

    }
    public class IOT_DEVICE_EDC_097
    {

        public int id { get; set; }
        public string device_id { get; set; }
        public string data_value_01 { get; set; }
        public string data_value_02 { get; set; }
        public string data_value_03 { get; set; }
        public string data_value_04 { get; set; }
        public string data_value_05 { get; set; }
        public string data_value_06 { get; set; }
        public string data_value_07 { get; set; }
        public string data_value_08 { get; set; }
        public string data_value_09 { get; set; }
        public string data_value_10 { get; set; }
        public string data_value_11 { get; set; }
        public string data_value_12 { get; set; }
        public string data_value_13 { get; set; }
        public string data_value_14 { get; set; }
        public string data_value_15 { get; set; }
        public string data_value_16 { get; set; }
        public string data_value_17 { get; set; }
        public string data_value_18 { get; set; }
        public string data_value_19 { get; set; }
        public string data_value_20 { get; set; }
        public string data_value_21 { get; set; }
        public string data_value_22 { get; set; }
        public string data_value_23 { get; set; }
        public string data_value_24 { get; set; }
        public string data_value_25 { get; set; }
        public string data_value_26 { get; set; }
        public string data_value_27 { get; set; }
        public string data_value_28 { get; set; }
        public string data_value_29 { get; set; }
        public string data_value_30 { get; set; }
        public string data_value_31 { get; set; }
        public string data_value_32 { get; set; }
        public string data_value_33 { get; set; }
        public string data_value_34 { get; set; }
        public string data_value_35 { get; set; }
        public string data_value_36 { get; set; }
        public string data_value_37 { get; set; }
        public string data_value_38 { get; set; }
        public string data_value_39 { get; set; }
        public string data_value_40 { get; set; }
        public DateTime clm_date_time { get; set; }
        public string clm_user { get; set; }

    }
    public class IOT_DEVICE_EDC_098
    {

        public int id { get; set; }
        public string device_id { get; set; }
        public string data_value_01 { get; set; }
        public string data_value_02 { get; set; }
        public string data_value_03 { get; set; }
        public string data_value_04 { get; set; }
        public string data_value_05 { get; set; }
        public string data_value_06 { get; set; }
        public string data_value_07 { get; set; }
        public string data_value_08 { get; set; }
        public string data_value_09 { get; set; }
        public string data_value_10 { get; set; }
        public string data_value_11 { get; set; }
        public string data_value_12 { get; set; }
        public string data_value_13 { get; set; }
        public string data_value_14 { get; set; }
        public string data_value_15 { get; set; }
        public string data_value_16 { get; set; }
        public string data_value_17 { get; set; }
        public string data_value_18 { get; set; }
        public string data_value_19 { get; set; }
        public string data_value_20 { get; set; }
        public string data_value_21 { get; set; }
        public string data_value_22 { get; set; }
        public string data_value_23 { get; set; }
        public string data_value_24 { get; set; }
        public string data_value_25 { get; set; }
        public string data_value_26 { get; set; }
        public string data_value_27 { get; set; }
        public string data_value_28 { get; set; }
        public string data_value_29 { get; set; }
        public string data_value_30 { get; set; }
        public string data_value_31 { get; set; }
        public string data_value_32 { get; set; }
        public string data_value_33 { get; set; }
        public string data_value_34 { get; set; }
        public string data_value_35 { get; set; }
        public string data_value_36 { get; set; }
        public string data_value_37 { get; set; }
        public string data_value_38 { get; set; }
        public string data_value_39 { get; set; }
        public string data_value_40 { get; set; }
        public DateTime clm_date_time { get; set; }
        public string clm_user { get; set; }

    }
    public class IOT_DEVICE_EDC_099
    {

        public int id { get; set; }
        public string device_id { get; set; }
        public string data_value_01 { get; set; }
        public string data_value_02 { get; set; }
        public string data_value_03 { get; set; }
        public string data_value_04 { get; set; }
        public string data_value_05 { get; set; }
        public string data_value_06 { get; set; }
        public string data_value_07 { get; set; }
        public string data_value_08 { get; set; }
        public string data_value_09 { get; set; }
        public string data_value_10 { get; set; }
        public string data_value_11 { get; set; }
        public string data_value_12 { get; set; }
        public string data_value_13 { get; set; }
        public string data_value_14 { get; set; }
        public string data_value_15 { get; set; }
        public string data_value_16 { get; set; }
        public string data_value_17 { get; set; }
        public string data_value_18 { get; set; }
        public string data_value_19 { get; set; }
        public string data_value_20 { get; set; }
        public string data_value_21 { get; set; }
        public string data_value_22 { get; set; }
        public string data_value_23 { get; set; }
        public string data_value_24 { get; set; }
        public string data_value_25 { get; set; }
        public string data_value_26 { get; set; }
        public string data_value_27 { get; set; }
        public string data_value_28 { get; set; }
        public string data_value_29 { get; set; }
        public string data_value_30 { get; set; }
        public string data_value_31 { get; set; }
        public string data_value_32 { get; set; }
        public string data_value_33 { get; set; }
        public string data_value_34 { get; set; }
        public string data_value_35 { get; set; }
        public string data_value_36 { get; set; }
        public string data_value_37 { get; set; }
        public string data_value_38 { get; set; }
        public string data_value_39 { get; set; }
        public string data_value_40 { get; set; }
        public DateTime clm_date_time { get; set; }
        public string clm_user { get; set; }

    }
    public class IOT_DEVICE_EDC_100
    {

        public int id { get; set; }
        public string device_id { get; set; }
        public string data_value_01 { get; set; }
        public string data_value_02 { get; set; }
        public string data_value_03 { get; set; }
        public string data_value_04 { get; set; }
        public string data_value_05 { get; set; }
        public string data_value_06 { get; set; }
        public string data_value_07 { get; set; }
        public string data_value_08 { get; set; }
        public string data_value_09 { get; set; }
        public string data_value_10 { get; set; }
        public string data_value_11 { get; set; }
        public string data_value_12 { get; set; }
        public string data_value_13 { get; set; }
        public string data_value_14 { get; set; }
        public string data_value_15 { get; set; }
        public string data_value_16 { get; set; }
        public string data_value_17 { get; set; }
        public string data_value_18 { get; set; }
        public string data_value_19 { get; set; }
        public string data_value_20 { get; set; }
        public string data_value_21 { get; set; }
        public string data_value_22 { get; set; }
        public string data_value_23 { get; set; }
        public string data_value_24 { get; set; }
        public string data_value_25 { get; set; }
        public string data_value_26 { get; set; }
        public string data_value_27 { get; set; }
        public string data_value_28 { get; set; }
        public string data_value_29 { get; set; }
        public string data_value_30 { get; set; }
        public string data_value_31 { get; set; }
        public string data_value_32 { get; set; }
        public string data_value_33 { get; set; }
        public string data_value_34 { get; set; }
        public string data_value_35 { get; set; }
        public string data_value_36 { get; set; }
        public string data_value_37 { get; set; }
        public string data_value_38 { get; set; }
        public string data_value_39 { get; set; }
        public string data_value_40 { get; set; }
        public DateTime clm_date_time { get; set; }
        public string clm_user { get; set; }

    }
    public class IOT_DEVICE_EDC_101
    {

        public int id { get; set; }
        public string device_id { get; set; }
        public string data_value_01 { get; set; }
        public string data_value_02 { get; set; }
        public string data_value_03 { get; set; }
        public string data_value_04 { get; set; }
        public string data_value_05 { get; set; }
        public string data_value_06 { get; set; }
        public string data_value_07 { get; set; }
        public string data_value_08 { get; set; }
        public string data_value_09 { get; set; }
        public string data_value_10 { get; set; }
        public string data_value_11 { get; set; }
        public string data_value_12 { get; set; }
        public string data_value_13 { get; set; }
        public string data_value_14 { get; set; }
        public string data_value_15 { get; set; }
        public string data_value_16 { get; set; }
        public string data_value_17 { get; set; }
        public string data_value_18 { get; set; }
        public string data_value_19 { get; set; }
        public string data_value_20 { get; set; }
        public string data_value_21 { get; set; }
        public string data_value_22 { get; set; }
        public string data_value_23 { get; set; }
        public string data_value_24 { get; set; }
        public string data_value_25 { get; set; }
        public string data_value_26 { get; set; }
        public string data_value_27 { get; set; }
        public string data_value_28 { get; set; }
        public string data_value_29 { get; set; }
        public string data_value_30 { get; set; }
        public string data_value_31 { get; set; }
        public string data_value_32 { get; set; }
        public string data_value_33 { get; set; }
        public string data_value_34 { get; set; }
        public string data_value_35 { get; set; }
        public string data_value_36 { get; set; }
        public string data_value_37 { get; set; }
        public string data_value_38 { get; set; }
        public string data_value_39 { get; set; }
        public string data_value_40 { get; set; }
        public DateTime clm_date_time { get; set; }
        public string clm_user { get; set; }

    }
    public class IOT_DEVICE_EDC_102
    {

        public int id { get; set; }
        public string device_id { get; set; }
        public string data_value_01 { get; set; }
        public string data_value_02 { get; set; }
        public string data_value_03 { get; set; }
        public string data_value_04 { get; set; }
        public string data_value_05 { get; set; }
        public string data_value_06 { get; set; }
        public string data_value_07 { get; set; }
        public string data_value_08 { get; set; }
        public string data_value_09 { get; set; }
        public string data_value_10 { get; set; }
        public string data_value_11 { get; set; }
        public string data_value_12 { get; set; }
        public string data_value_13 { get; set; }
        public string data_value_14 { get; set; }
        public string data_value_15 { get; set; }
        public string data_value_16 { get; set; }
        public string data_value_17 { get; set; }
        public string data_value_18 { get; set; }
        public string data_value_19 { get; set; }
        public string data_value_20 { get; set; }
        public string data_value_21 { get; set; }
        public string data_value_22 { get; set; }
        public string data_value_23 { get; set; }
        public string data_value_24 { get; set; }
        public string data_value_25 { get; set; }
        public string data_value_26 { get; set; }
        public string data_value_27 { get; set; }
        public string data_value_28 { get; set; }
        public string data_value_29 { get; set; }
        public string data_value_30 { get; set; }
        public string data_value_31 { get; set; }
        public string data_value_32 { get; set; }
        public string data_value_33 { get; set; }
        public string data_value_34 { get; set; }
        public string data_value_35 { get; set; }
        public string data_value_36 { get; set; }
        public string data_value_37 { get; set; }
        public string data_value_38 { get; set; }
        public string data_value_39 { get; set; }
        public string data_value_40 { get; set; }
        public DateTime clm_date_time { get; set; }
        public string clm_user { get; set; }

    }
    public class IOT_DEVICE_EDC_103
    {

        public int id { get; set; }
        public string device_id { get; set; }
        public string data_value_01 { get; set; }
        public string data_value_02 { get; set; }
        public string data_value_03 { get; set; }
        public string data_value_04 { get; set; }
        public string data_value_05 { get; set; }
        public string data_value_06 { get; set; }
        public string data_value_07 { get; set; }
        public string data_value_08 { get; set; }
        public string data_value_09 { get; set; }
        public string data_value_10 { get; set; }
        public string data_value_11 { get; set; }
        public string data_value_12 { get; set; }
        public string data_value_13 { get; set; }
        public string data_value_14 { get; set; }
        public string data_value_15 { get; set; }
        public string data_value_16 { get; set; }
        public string data_value_17 { get; set; }
        public string data_value_18 { get; set; }
        public string data_value_19 { get; set; }
        public string data_value_20 { get; set; }
        public string data_value_21 { get; set; }
        public string data_value_22 { get; set; }
        public string data_value_23 { get; set; }
        public string data_value_24 { get; set; }
        public string data_value_25 { get; set; }
        public string data_value_26 { get; set; }
        public string data_value_27 { get; set; }
        public string data_value_28 { get; set; }
        public string data_value_29 { get; set; }
        public string data_value_30 { get; set; }
        public string data_value_31 { get; set; }
        public string data_value_32 { get; set; }
        public string data_value_33 { get; set; }
        public string data_value_34 { get; set; }
        public string data_value_35 { get; set; }
        public string data_value_36 { get; set; }
        public string data_value_37 { get; set; }
        public string data_value_38 { get; set; }
        public string data_value_39 { get; set; }
        public string data_value_40 { get; set; }
        public DateTime clm_date_time { get; set; }
        public string clm_user { get; set; }

    }
    public class IOT_DEVICE_EDC_104
    {

        public int id { get; set; }
        public string device_id { get; set; }
        public string data_value_01 { get; set; }
        public string data_value_02 { get; set; }
        public string data_value_03 { get; set; }
        public string data_value_04 { get; set; }
        public string data_value_05 { get; set; }
        public string data_value_06 { get; set; }
        public string data_value_07 { get; set; }
        public string data_value_08 { get; set; }
        public string data_value_09 { get; set; }
        public string data_value_10 { get; set; }
        public string data_value_11 { get; set; }
        public string data_value_12 { get; set; }
        public string data_value_13 { get; set; }
        public string data_value_14 { get; set; }
        public string data_value_15 { get; set; }
        public string data_value_16 { get; set; }
        public string data_value_17 { get; set; }
        public string data_value_18 { get; set; }
        public string data_value_19 { get; set; }
        public string data_value_20 { get; set; }
        public string data_value_21 { get; set; }
        public string data_value_22 { get; set; }
        public string data_value_23 { get; set; }
        public string data_value_24 { get; set; }
        public string data_value_25 { get; set; }
        public string data_value_26 { get; set; }
        public string data_value_27 { get; set; }
        public string data_value_28 { get; set; }
        public string data_value_29 { get; set; }
        public string data_value_30 { get; set; }
        public string data_value_31 { get; set; }
        public string data_value_32 { get; set; }
        public string data_value_33 { get; set; }
        public string data_value_34 { get; set; }
        public string data_value_35 { get; set; }
        public string data_value_36 { get; set; }
        public string data_value_37 { get; set; }
        public string data_value_38 { get; set; }
        public string data_value_39 { get; set; }
        public string data_value_40 { get; set; }
        public DateTime clm_date_time { get; set; }
        public string clm_user { get; set; }

    }
    public class IOT_DEVICE_EDC_105
    {

        public int id { get; set; }
        public string device_id { get; set; }
        public string data_value_01 { get; set; }
        public string data_value_02 { get; set; }
        public string data_value_03 { get; set; }
        public string data_value_04 { get; set; }
        public string data_value_05 { get; set; }
        public string data_value_06 { get; set; }
        public string data_value_07 { get; set; }
        public string data_value_08 { get; set; }
        public string data_value_09 { get; set; }
        public string data_value_10 { get; set; }
        public string data_value_11 { get; set; }
        public string data_value_12 { get; set; }
        public string data_value_13 { get; set; }
        public string data_value_14 { get; set; }
        public string data_value_15 { get; set; }
        public string data_value_16 { get; set; }
        public string data_value_17 { get; set; }
        public string data_value_18 { get; set; }
        public string data_value_19 { get; set; }
        public string data_value_20 { get; set; }
        public string data_value_21 { get; set; }
        public string data_value_22 { get; set; }
        public string data_value_23 { get; set; }
        public string data_value_24 { get; set; }
        public string data_value_25 { get; set; }
        public string data_value_26 { get; set; }
        public string data_value_27 { get; set; }
        public string data_value_28 { get; set; }
        public string data_value_29 { get; set; }
        public string data_value_30 { get; set; }
        public string data_value_31 { get; set; }
        public string data_value_32 { get; set; }
        public string data_value_33 { get; set; }
        public string data_value_34 { get; set; }
        public string data_value_35 { get; set; }
        public string data_value_36 { get; set; }
        public string data_value_37 { get; set; }
        public string data_value_38 { get; set; }
        public string data_value_39 { get; set; }
        public string data_value_40 { get; set; }
        public DateTime clm_date_time { get; set; }
        public string clm_user { get; set; }

    }
    public class IOT_DEVICE_EDC_106
    {

        public int id { get; set; }
        public string device_id { get; set; }
        public string data_value_01 { get; set; }
        public string data_value_02 { get; set; }
        public string data_value_03 { get; set; }
        public string data_value_04 { get; set; }
        public string data_value_05 { get; set; }
        public string data_value_06 { get; set; }
        public string data_value_07 { get; set; }
        public string data_value_08 { get; set; }
        public string data_value_09 { get; set; }
        public string data_value_10 { get; set; }
        public string data_value_11 { get; set; }
        public string data_value_12 { get; set; }
        public string data_value_13 { get; set; }
        public string data_value_14 { get; set; }
        public string data_value_15 { get; set; }
        public string data_value_16 { get; set; }
        public string data_value_17 { get; set; }
        public string data_value_18 { get; set; }
        public string data_value_19 { get; set; }
        public string data_value_20 { get; set; }
        public string data_value_21 { get; set; }
        public string data_value_22 { get; set; }
        public string data_value_23 { get; set; }
        public string data_value_24 { get; set; }
        public string data_value_25 { get; set; }
        public string data_value_26 { get; set; }
        public string data_value_27 { get; set; }
        public string data_value_28 { get; set; }
        public string data_value_29 { get; set; }
        public string data_value_30 { get; set; }
        public string data_value_31 { get; set; }
        public string data_value_32 { get; set; }
        public string data_value_33 { get; set; }
        public string data_value_34 { get; set; }
        public string data_value_35 { get; set; }
        public string data_value_36 { get; set; }
        public string data_value_37 { get; set; }
        public string data_value_38 { get; set; }
        public string data_value_39 { get; set; }
        public string data_value_40 { get; set; }
        public DateTime clm_date_time { get; set; }
        public string clm_user { get; set; }

    }
    public class IOT_DEVICE_EDC_107
    {

        public int id { get; set; }
        public string device_id { get; set; }
        public string data_value_01 { get; set; }
        public string data_value_02 { get; set; }
        public string data_value_03 { get; set; }
        public string data_value_04 { get; set; }
        public string data_value_05 { get; set; }
        public string data_value_06 { get; set; }
        public string data_value_07 { get; set; }
        public string data_value_08 { get; set; }
        public string data_value_09 { get; set; }
        public string data_value_10 { get; set; }
        public string data_value_11 { get; set; }
        public string data_value_12 { get; set; }
        public string data_value_13 { get; set; }
        public string data_value_14 { get; set; }
        public string data_value_15 { get; set; }
        public string data_value_16 { get; set; }
        public string data_value_17 { get; set; }
        public string data_value_18 { get; set; }
        public string data_value_19 { get; set; }
        public string data_value_20 { get; set; }
        public string data_value_21 { get; set; }
        public string data_value_22 { get; set; }
        public string data_value_23 { get; set; }
        public string data_value_24 { get; set; }
        public string data_value_25 { get; set; }
        public string data_value_26 { get; set; }
        public string data_value_27 { get; set; }
        public string data_value_28 { get; set; }
        public string data_value_29 { get; set; }
        public string data_value_30 { get; set; }
        public string data_value_31 { get; set; }
        public string data_value_32 { get; set; }
        public string data_value_33 { get; set; }
        public string data_value_34 { get; set; }
        public string data_value_35 { get; set; }
        public string data_value_36 { get; set; }
        public string data_value_37 { get; set; }
        public string data_value_38 { get; set; }
        public string data_value_39 { get; set; }
        public string data_value_40 { get; set; }
        public DateTime clm_date_time { get; set; }
        public string clm_user { get; set; }

    }
    public class IOT_DEVICE_EDC_108
    {

        public int id { get; set; }
        public string device_id { get; set; }
        public string data_value_01 { get; set; }
        public string data_value_02 { get; set; }
        public string data_value_03 { get; set; }
        public string data_value_04 { get; set; }
        public string data_value_05 { get; set; }
        public string data_value_06 { get; set; }
        public string data_value_07 { get; set; }
        public string data_value_08 { get; set; }
        public string data_value_09 { get; set; }
        public string data_value_10 { get; set; }
        public string data_value_11 { get; set; }
        public string data_value_12 { get; set; }
        public string data_value_13 { get; set; }
        public string data_value_14 { get; set; }
        public string data_value_15 { get; set; }
        public string data_value_16 { get; set; }
        public string data_value_17 { get; set; }
        public string data_value_18 { get; set; }
        public string data_value_19 { get; set; }
        public string data_value_20 { get; set; }
        public string data_value_21 { get; set; }
        public string data_value_22 { get; set; }
        public string data_value_23 { get; set; }
        public string data_value_24 { get; set; }
        public string data_value_25 { get; set; }
        public string data_value_26 { get; set; }
        public string data_value_27 { get; set; }
        public string data_value_28 { get; set; }
        public string data_value_29 { get; set; }
        public string data_value_30 { get; set; }
        public string data_value_31 { get; set; }
        public string data_value_32 { get; set; }
        public string data_value_33 { get; set; }
        public string data_value_34 { get; set; }
        public string data_value_35 { get; set; }
        public string data_value_36 { get; set; }
        public string data_value_37 { get; set; }
        public string data_value_38 { get; set; }
        public string data_value_39 { get; set; }
        public string data_value_40 { get; set; }
        public DateTime clm_date_time { get; set; }
        public string clm_user { get; set; }

    }
    public class IOT_DEVICE_EDC_109
    {

        public int id { get; set; }
        public string device_id { get; set; }
        public string data_value_01 { get; set; }
        public string data_value_02 { get; set; }
        public string data_value_03 { get; set; }
        public string data_value_04 { get; set; }
        public string data_value_05 { get; set; }
        public string data_value_06 { get; set; }
        public string data_value_07 { get; set; }
        public string data_value_08 { get; set; }
        public string data_value_09 { get; set; }
        public string data_value_10 { get; set; }
        public string data_value_11 { get; set; }
        public string data_value_12 { get; set; }
        public string data_value_13 { get; set; }
        public string data_value_14 { get; set; }
        public string data_value_15 { get; set; }
        public string data_value_16 { get; set; }
        public string data_value_17 { get; set; }
        public string data_value_18 { get; set; }
        public string data_value_19 { get; set; }
        public string data_value_20 { get; set; }
        public string data_value_21 { get; set; }
        public string data_value_22 { get; set; }
        public string data_value_23 { get; set; }
        public string data_value_24 { get; set; }
        public string data_value_25 { get; set; }
        public string data_value_26 { get; set; }
        public string data_value_27 { get; set; }
        public string data_value_28 { get; set; }
        public string data_value_29 { get; set; }
        public string data_value_30 { get; set; }
        public string data_value_31 { get; set; }
        public string data_value_32 { get; set; }
        public string data_value_33 { get; set; }
        public string data_value_34 { get; set; }
        public string data_value_35 { get; set; }
        public string data_value_36 { get; set; }
        public string data_value_37 { get; set; }
        public string data_value_38 { get; set; }
        public string data_value_39 { get; set; }
        public string data_value_40 { get; set; }
        public DateTime clm_date_time { get; set; }
        public string clm_user { get; set; }

    }
    public class IOT_DEVICE_EDC_110
    {

        public int id { get; set; }
        public string device_id { get; set; }
        public string data_value_01 { get; set; }
        public string data_value_02 { get; set; }
        public string data_value_03 { get; set; }
        public string data_value_04 { get; set; }
        public string data_value_05 { get; set; }
        public string data_value_06 { get; set; }
        public string data_value_07 { get; set; }
        public string data_value_08 { get; set; }
        public string data_value_09 { get; set; }
        public string data_value_10 { get; set; }
        public string data_value_11 { get; set; }
        public string data_value_12 { get; set; }
        public string data_value_13 { get; set; }
        public string data_value_14 { get; set; }
        public string data_value_15 { get; set; }
        public string data_value_16 { get; set; }
        public string data_value_17 { get; set; }
        public string data_value_18 { get; set; }
        public string data_value_19 { get; set; }
        public string data_value_20 { get; set; }
        public string data_value_21 { get; set; }
        public string data_value_22 { get; set; }
        public string data_value_23 { get; set; }
        public string data_value_24 { get; set; }
        public string data_value_25 { get; set; }
        public string data_value_26 { get; set; }
        public string data_value_27 { get; set; }
        public string data_value_28 { get; set; }
        public string data_value_29 { get; set; }
        public string data_value_30 { get; set; }
        public string data_value_31 { get; set; }
        public string data_value_32 { get; set; }
        public string data_value_33 { get; set; }
        public string data_value_34 { get; set; }
        public string data_value_35 { get; set; }
        public string data_value_36 { get; set; }
        public string data_value_37 { get; set; }
        public string data_value_38 { get; set; }
        public string data_value_39 { get; set; }
        public string data_value_40 { get; set; }
        public DateTime clm_date_time { get; set; }
        public string clm_user { get; set; }

    }
    public class IOT_DEVICE_EDC_111
    {

        public int id { get; set; }
        public string device_id { get; set; }
        public string data_value_01 { get; set; }
        public string data_value_02 { get; set; }
        public string data_value_03 { get; set; }
        public string data_value_04 { get; set; }
        public string data_value_05 { get; set; }
        public string data_value_06 { get; set; }
        public string data_value_07 { get; set; }
        public string data_value_08 { get; set; }
        public string data_value_09 { get; set; }
        public string data_value_10 { get; set; }
        public string data_value_11 { get; set; }
        public string data_value_12 { get; set; }
        public string data_value_13 { get; set; }
        public string data_value_14 { get; set; }
        public string data_value_15 { get; set; }
        public string data_value_16 { get; set; }
        public string data_value_17 { get; set; }
        public string data_value_18 { get; set; }
        public string data_value_19 { get; set; }
        public string data_value_20 { get; set; }
        public string data_value_21 { get; set; }
        public string data_value_22 { get; set; }
        public string data_value_23 { get; set; }
        public string data_value_24 { get; set; }
        public string data_value_25 { get; set; }
        public string data_value_26 { get; set; }
        public string data_value_27 { get; set; }
        public string data_value_28 { get; set; }
        public string data_value_29 { get; set; }
        public string data_value_30 { get; set; }
        public string data_value_31 { get; set; }
        public string data_value_32 { get; set; }
        public string data_value_33 { get; set; }
        public string data_value_34 { get; set; }
        public string data_value_35 { get; set; }
        public string data_value_36 { get; set; }
        public string data_value_37 { get; set; }
        public string data_value_38 { get; set; }
        public string data_value_39 { get; set; }
        public string data_value_40 { get; set; }
        public DateTime clm_date_time { get; set; }
        public string clm_user { get; set; }

    }
    public class IOT_DEVICE_EDC_112
    {

        public int id { get; set; }
        public string device_id { get; set; }
        public string data_value_01 { get; set; }
        public string data_value_02 { get; set; }
        public string data_value_03 { get; set; }
        public string data_value_04 { get; set; }
        public string data_value_05 { get; set; }
        public string data_value_06 { get; set; }
        public string data_value_07 { get; set; }
        public string data_value_08 { get; set; }
        public string data_value_09 { get; set; }
        public string data_value_10 { get; set; }
        public string data_value_11 { get; set; }
        public string data_value_12 { get; set; }
        public string data_value_13 { get; set; }
        public string data_value_14 { get; set; }
        public string data_value_15 { get; set; }
        public string data_value_16 { get; set; }
        public string data_value_17 { get; set; }
        public string data_value_18 { get; set; }
        public string data_value_19 { get; set; }
        public string data_value_20 { get; set; }
        public string data_value_21 { get; set; }
        public string data_value_22 { get; set; }
        public string data_value_23 { get; set; }
        public string data_value_24 { get; set; }
        public string data_value_25 { get; set; }
        public string data_value_26 { get; set; }
        public string data_value_27 { get; set; }
        public string data_value_28 { get; set; }
        public string data_value_29 { get; set; }
        public string data_value_30 { get; set; }
        public string data_value_31 { get; set; }
        public string data_value_32 { get; set; }
        public string data_value_33 { get; set; }
        public string data_value_34 { get; set; }
        public string data_value_35 { get; set; }
        public string data_value_36 { get; set; }
        public string data_value_37 { get; set; }
        public string data_value_38 { get; set; }
        public string data_value_39 { get; set; }
        public string data_value_40 { get; set; }
        public DateTime clm_date_time { get; set; }
        public string clm_user { get; set; }

    }
    public class IOT_DEVICE_EDC_113
    {

        public int id { get; set; }
        public string device_id { get; set; }
        public string data_value_01 { get; set; }
        public string data_value_02 { get; set; }
        public string data_value_03 { get; set; }
        public string data_value_04 { get; set; }
        public string data_value_05 { get; set; }
        public string data_value_06 { get; set; }
        public string data_value_07 { get; set; }
        public string data_value_08 { get; set; }
        public string data_value_09 { get; set; }
        public string data_value_10 { get; set; }
        public string data_value_11 { get; set; }
        public string data_value_12 { get; set; }
        public string data_value_13 { get; set; }
        public string data_value_14 { get; set; }
        public string data_value_15 { get; set; }
        public string data_value_16 { get; set; }
        public string data_value_17 { get; set; }
        public string data_value_18 { get; set; }
        public string data_value_19 { get; set; }
        public string data_value_20 { get; set; }
        public string data_value_21 { get; set; }
        public string data_value_22 { get; set; }
        public string data_value_23 { get; set; }
        public string data_value_24 { get; set; }
        public string data_value_25 { get; set; }
        public string data_value_26 { get; set; }
        public string data_value_27 { get; set; }
        public string data_value_28 { get; set; }
        public string data_value_29 { get; set; }
        public string data_value_30 { get; set; }
        public string data_value_31 { get; set; }
        public string data_value_32 { get; set; }
        public string data_value_33 { get; set; }
        public string data_value_34 { get; set; }
        public string data_value_35 { get; set; }
        public string data_value_36 { get; set; }
        public string data_value_37 { get; set; }
        public string data_value_38 { get; set; }
        public string data_value_39 { get; set; }
        public string data_value_40 { get; set; }
        public DateTime clm_date_time { get; set; }
        public string clm_user { get; set; }

    }
    public class IOT_DEVICE_EDC_114
    {

        public int id { get; set; }
        public string device_id { get; set; }
        public string data_value_01 { get; set; }
        public string data_value_02 { get; set; }
        public string data_value_03 { get; set; }
        public string data_value_04 { get; set; }
        public string data_value_05 { get; set; }
        public string data_value_06 { get; set; }
        public string data_value_07 { get; set; }
        public string data_value_08 { get; set; }
        public string data_value_09 { get; set; }
        public string data_value_10 { get; set; }
        public string data_value_11 { get; set; }
        public string data_value_12 { get; set; }
        public string data_value_13 { get; set; }
        public string data_value_14 { get; set; }
        public string data_value_15 { get; set; }
        public string data_value_16 { get; set; }
        public string data_value_17 { get; set; }
        public string data_value_18 { get; set; }
        public string data_value_19 { get; set; }
        public string data_value_20 { get; set; }
        public string data_value_21 { get; set; }
        public string data_value_22 { get; set; }
        public string data_value_23 { get; set; }
        public string data_value_24 { get; set; }
        public string data_value_25 { get; set; }
        public string data_value_26 { get; set; }
        public string data_value_27 { get; set; }
        public string data_value_28 { get; set; }
        public string data_value_29 { get; set; }
        public string data_value_30 { get; set; }
        public string data_value_31 { get; set; }
        public string data_value_32 { get; set; }
        public string data_value_33 { get; set; }
        public string data_value_34 { get; set; }
        public string data_value_35 { get; set; }
        public string data_value_36 { get; set; }
        public string data_value_37 { get; set; }
        public string data_value_38 { get; set; }
        public string data_value_39 { get; set; }
        public string data_value_40 { get; set; }
        public DateTime clm_date_time { get; set; }
        public string clm_user { get; set; }

    }
    public class IOT_DEVICE_EDC_115
    {

        public int id { get; set; }
        public string device_id { get; set; }
        public string data_value_01 { get; set; }
        public string data_value_02 { get; set; }
        public string data_value_03 { get; set; }
        public string data_value_04 { get; set; }
        public string data_value_05 { get; set; }
        public string data_value_06 { get; set; }
        public string data_value_07 { get; set; }
        public string data_value_08 { get; set; }
        public string data_value_09 { get; set; }
        public string data_value_10 { get; set; }
        public string data_value_11 { get; set; }
        public string data_value_12 { get; set; }
        public string data_value_13 { get; set; }
        public string data_value_14 { get; set; }
        public string data_value_15 { get; set; }
        public string data_value_16 { get; set; }
        public string data_value_17 { get; set; }
        public string data_value_18 { get; set; }
        public string data_value_19 { get; set; }
        public string data_value_20 { get; set; }
        public string data_value_21 { get; set; }
        public string data_value_22 { get; set; }
        public string data_value_23 { get; set; }
        public string data_value_24 { get; set; }
        public string data_value_25 { get; set; }
        public string data_value_26 { get; set; }
        public string data_value_27 { get; set; }
        public string data_value_28 { get; set; }
        public string data_value_29 { get; set; }
        public string data_value_30 { get; set; }
        public string data_value_31 { get; set; }
        public string data_value_32 { get; set; }
        public string data_value_33 { get; set; }
        public string data_value_34 { get; set; }
        public string data_value_35 { get; set; }
        public string data_value_36 { get; set; }
        public string data_value_37 { get; set; }
        public string data_value_38 { get; set; }
        public string data_value_39 { get; set; }
        public string data_value_40 { get; set; }
        public DateTime clm_date_time { get; set; }
        public string clm_user { get; set; }

    }
    public class IOT_DEVICE_EDC_116
    {

        public int id { get; set; }
        public string device_id { get; set; }
        public string data_value_01 { get; set; }
        public string data_value_02 { get; set; }
        public string data_value_03 { get; set; }
        public string data_value_04 { get; set; }
        public string data_value_05 { get; set; }
        public string data_value_06 { get; set; }
        public string data_value_07 { get; set; }
        public string data_value_08 { get; set; }
        public string data_value_09 { get; set; }
        public string data_value_10 { get; set; }
        public string data_value_11 { get; set; }
        public string data_value_12 { get; set; }
        public string data_value_13 { get; set; }
        public string data_value_14 { get; set; }
        public string data_value_15 { get; set; }
        public string data_value_16 { get; set; }
        public string data_value_17 { get; set; }
        public string data_value_18 { get; set; }
        public string data_value_19 { get; set; }
        public string data_value_20 { get; set; }
        public string data_value_21 { get; set; }
        public string data_value_22 { get; set; }
        public string data_value_23 { get; set; }
        public string data_value_24 { get; set; }
        public string data_value_25 { get; set; }
        public string data_value_26 { get; set; }
        public string data_value_27 { get; set; }
        public string data_value_28 { get; set; }
        public string data_value_29 { get; set; }
        public string data_value_30 { get; set; }
        public string data_value_31 { get; set; }
        public string data_value_32 { get; set; }
        public string data_value_33 { get; set; }
        public string data_value_34 { get; set; }
        public string data_value_35 { get; set; }
        public string data_value_36 { get; set; }
        public string data_value_37 { get; set; }
        public string data_value_38 { get; set; }
        public string data_value_39 { get; set; }
        public string data_value_40 { get; set; }
        public DateTime clm_date_time { get; set; }
        public string clm_user { get; set; }

    }
    public class IOT_DEVICE_EDC_117
    {

        public int id { get; set; }
        public string device_id { get; set; }
        public string data_value_01 { get; set; }
        public string data_value_02 { get; set; }
        public string data_value_03 { get; set; }
        public string data_value_04 { get; set; }
        public string data_value_05 { get; set; }
        public string data_value_06 { get; set; }
        public string data_value_07 { get; set; }
        public string data_value_08 { get; set; }
        public string data_value_09 { get; set; }
        public string data_value_10 { get; set; }
        public string data_value_11 { get; set; }
        public string data_value_12 { get; set; }
        public string data_value_13 { get; set; }
        public string data_value_14 { get; set; }
        public string data_value_15 { get; set; }
        public string data_value_16 { get; set; }
        public string data_value_17 { get; set; }
        public string data_value_18 { get; set; }
        public string data_value_19 { get; set; }
        public string data_value_20 { get; set; }
        public string data_value_21 { get; set; }
        public string data_value_22 { get; set; }
        public string data_value_23 { get; set; }
        public string data_value_24 { get; set; }
        public string data_value_25 { get; set; }
        public string data_value_26 { get; set; }
        public string data_value_27 { get; set; }
        public string data_value_28 { get; set; }
        public string data_value_29 { get; set; }
        public string data_value_30 { get; set; }
        public string data_value_31 { get; set; }
        public string data_value_32 { get; set; }
        public string data_value_33 { get; set; }
        public string data_value_34 { get; set; }
        public string data_value_35 { get; set; }
        public string data_value_36 { get; set; }
        public string data_value_37 { get; set; }
        public string data_value_38 { get; set; }
        public string data_value_39 { get; set; }
        public string data_value_40 { get; set; }
        public DateTime clm_date_time { get; set; }
        public string clm_user { get; set; }

    }
    public class IOT_DEVICE_EDC_118
    {

        public int id { get; set; }
        public string device_id { get; set; }
        public string data_value_01 { get; set; }
        public string data_value_02 { get; set; }
        public string data_value_03 { get; set; }
        public string data_value_04 { get; set; }
        public string data_value_05 { get; set; }
        public string data_value_06 { get; set; }
        public string data_value_07 { get; set; }
        public string data_value_08 { get; set; }
        public string data_value_09 { get; set; }
        public string data_value_10 { get; set; }
        public string data_value_11 { get; set; }
        public string data_value_12 { get; set; }
        public string data_value_13 { get; set; }
        public string data_value_14 { get; set; }
        public string data_value_15 { get; set; }
        public string data_value_16 { get; set; }
        public string data_value_17 { get; set; }
        public string data_value_18 { get; set; }
        public string data_value_19 { get; set; }
        public string data_value_20 { get; set; }
        public string data_value_21 { get; set; }
        public string data_value_22 { get; set; }
        public string data_value_23 { get; set; }
        public string data_value_24 { get; set; }
        public string data_value_25 { get; set; }
        public string data_value_26 { get; set; }
        public string data_value_27 { get; set; }
        public string data_value_28 { get; set; }
        public string data_value_29 { get; set; }
        public string data_value_30 { get; set; }
        public string data_value_31 { get; set; }
        public string data_value_32 { get; set; }
        public string data_value_33 { get; set; }
        public string data_value_34 { get; set; }
        public string data_value_35 { get; set; }
        public string data_value_36 { get; set; }
        public string data_value_37 { get; set; }
        public string data_value_38 { get; set; }
        public string data_value_39 { get; set; }
        public string data_value_40 { get; set; }
        public DateTime clm_date_time { get; set; }
        public string clm_user { get; set; }

    }
    public class IOT_DEVICE_EDC_119
    {

        public int id { get; set; }
        public string device_id { get; set; }
        public string data_value_01 { get; set; }
        public string data_value_02 { get; set; }
        public string data_value_03 { get; set; }
        public string data_value_04 { get; set; }
        public string data_value_05 { get; set; }
        public string data_value_06 { get; set; }
        public string data_value_07 { get; set; }
        public string data_value_08 { get; set; }
        public string data_value_09 { get; set; }
        public string data_value_10 { get; set; }
        public string data_value_11 { get; set; }
        public string data_value_12 { get; set; }
        public string data_value_13 { get; set; }
        public string data_value_14 { get; set; }
        public string data_value_15 { get; set; }
        public string data_value_16 { get; set; }
        public string data_value_17 { get; set; }
        public string data_value_18 { get; set; }
        public string data_value_19 { get; set; }
        public string data_value_20 { get; set; }
        public string data_value_21 { get; set; }
        public string data_value_22 { get; set; }
        public string data_value_23 { get; set; }
        public string data_value_24 { get; set; }
        public string data_value_25 { get; set; }
        public string data_value_26 { get; set; }
        public string data_value_27 { get; set; }
        public string data_value_28 { get; set; }
        public string data_value_29 { get; set; }
        public string data_value_30 { get; set; }
        public string data_value_31 { get; set; }
        public string data_value_32 { get; set; }
        public string data_value_33 { get; set; }
        public string data_value_34 { get; set; }
        public string data_value_35 { get; set; }
        public string data_value_36 { get; set; }
        public string data_value_37 { get; set; }
        public string data_value_38 { get; set; }
        public string data_value_39 { get; set; }
        public string data_value_40 { get; set; }
        public DateTime clm_date_time { get; set; }
        public string clm_user { get; set; }

    }
    public class IOT_DEVICE_EDC_120
    {

        public int id { get; set; }
        public string device_id { get; set; }
        public string data_value_01 { get; set; }
        public string data_value_02 { get; set; }
        public string data_value_03 { get; set; }
        public string data_value_04 { get; set; }
        public string data_value_05 { get; set; }
        public string data_value_06 { get; set; }
        public string data_value_07 { get; set; }
        public string data_value_08 { get; set; }
        public string data_value_09 { get; set; }
        public string data_value_10 { get; set; }
        public string data_value_11 { get; set; }
        public string data_value_12 { get; set; }
        public string data_value_13 { get; set; }
        public string data_value_14 { get; set; }
        public string data_value_15 { get; set; }
        public string data_value_16 { get; set; }
        public string data_value_17 { get; set; }
        public string data_value_18 { get; set; }
        public string data_value_19 { get; set; }
        public string data_value_20 { get; set; }
        public string data_value_21 { get; set; }
        public string data_value_22 { get; set; }
        public string data_value_23 { get; set; }
        public string data_value_24 { get; set; }
        public string data_value_25 { get; set; }
        public string data_value_26 { get; set; }
        public string data_value_27 { get; set; }
        public string data_value_28 { get; set; }
        public string data_value_29 { get; set; }
        public string data_value_30 { get; set; }
        public string data_value_31 { get; set; }
        public string data_value_32 { get; set; }
        public string data_value_33 { get; set; }
        public string data_value_34 { get; set; }
        public string data_value_35 { get; set; }
        public string data_value_36 { get; set; }
        public string data_value_37 { get; set; }
        public string data_value_38 { get; set; }
        public string data_value_39 { get; set; }
        public string data_value_40 { get; set; }
        public DateTime clm_date_time { get; set; }
        public string clm_user { get; set; }

    }
    public class IOT_DEVICE_EDC_121
    {

        public int id { get; set; }
        public string device_id { get; set; }
        public string data_value_01 { get; set; }
        public string data_value_02 { get; set; }
        public string data_value_03 { get; set; }
        public string data_value_04 { get; set; }
        public string data_value_05 { get; set; }
        public string data_value_06 { get; set; }
        public string data_value_07 { get; set; }
        public string data_value_08 { get; set; }
        public string data_value_09 { get; set; }
        public string data_value_10 { get; set; }
        public string data_value_11 { get; set; }
        public string data_value_12 { get; set; }
        public string data_value_13 { get; set; }
        public string data_value_14 { get; set; }
        public string data_value_15 { get; set; }
        public string data_value_16 { get; set; }
        public string data_value_17 { get; set; }
        public string data_value_18 { get; set; }
        public string data_value_19 { get; set; }
        public string data_value_20 { get; set; }
        public string data_value_21 { get; set; }
        public string data_value_22 { get; set; }
        public string data_value_23 { get; set; }
        public string data_value_24 { get; set; }
        public string data_value_25 { get; set; }
        public string data_value_26 { get; set; }
        public string data_value_27 { get; set; }
        public string data_value_28 { get; set; }
        public string data_value_29 { get; set; }
        public string data_value_30 { get; set; }
        public string data_value_31 { get; set; }
        public string data_value_32 { get; set; }
        public string data_value_33 { get; set; }
        public string data_value_34 { get; set; }
        public string data_value_35 { get; set; }
        public string data_value_36 { get; set; }
        public string data_value_37 { get; set; }
        public string data_value_38 { get; set; }
        public string data_value_39 { get; set; }
        public string data_value_40 { get; set; }
        public DateTime clm_date_time { get; set; }
        public string clm_user { get; set; }

    }
    public class IOT_DEVICE_EDC_122
    {

        public int id { get; set; }
        public string device_id { get; set; }
        public string data_value_01 { get; set; }
        public string data_value_02 { get; set; }
        public string data_value_03 { get; set; }
        public string data_value_04 { get; set; }
        public string data_value_05 { get; set; }
        public string data_value_06 { get; set; }
        public string data_value_07 { get; set; }
        public string data_value_08 { get; set; }
        public string data_value_09 { get; set; }
        public string data_value_10 { get; set; }
        public string data_value_11 { get; set; }
        public string data_value_12 { get; set; }
        public string data_value_13 { get; set; }
        public string data_value_14 { get; set; }
        public string data_value_15 { get; set; }
        public string data_value_16 { get; set; }
        public string data_value_17 { get; set; }
        public string data_value_18 { get; set; }
        public string data_value_19 { get; set; }
        public string data_value_20 { get; set; }
        public string data_value_21 { get; set; }
        public string data_value_22 { get; set; }
        public string data_value_23 { get; set; }
        public string data_value_24 { get; set; }
        public string data_value_25 { get; set; }
        public string data_value_26 { get; set; }
        public string data_value_27 { get; set; }
        public string data_value_28 { get; set; }
        public string data_value_29 { get; set; }
        public string data_value_30 { get; set; }
        public string data_value_31 { get; set; }
        public string data_value_32 { get; set; }
        public string data_value_33 { get; set; }
        public string data_value_34 { get; set; }
        public string data_value_35 { get; set; }
        public string data_value_36 { get; set; }
        public string data_value_37 { get; set; }
        public string data_value_38 { get; set; }
        public string data_value_39 { get; set; }
        public string data_value_40 { get; set; }
        public DateTime clm_date_time { get; set; }
        public string clm_user { get; set; }

    }
    public class IOT_DEVICE_EDC_123
    {

        public int id { get; set; }
        public string device_id { get; set; }
        public string data_value_01 { get; set; }
        public string data_value_02 { get; set; }
        public string data_value_03 { get; set; }
        public string data_value_04 { get; set; }
        public string data_value_05 { get; set; }
        public string data_value_06 { get; set; }
        public string data_value_07 { get; set; }
        public string data_value_08 { get; set; }
        public string data_value_09 { get; set; }
        public string data_value_10 { get; set; }
        public string data_value_11 { get; set; }
        public string data_value_12 { get; set; }
        public string data_value_13 { get; set; }
        public string data_value_14 { get; set; }
        public string data_value_15 { get; set; }
        public string data_value_16 { get; set; }
        public string data_value_17 { get; set; }
        public string data_value_18 { get; set; }
        public string data_value_19 { get; set; }
        public string data_value_20 { get; set; }
        public string data_value_21 { get; set; }
        public string data_value_22 { get; set; }
        public string data_value_23 { get; set; }
        public string data_value_24 { get; set; }
        public string data_value_25 { get; set; }
        public string data_value_26 { get; set; }
        public string data_value_27 { get; set; }
        public string data_value_28 { get; set; }
        public string data_value_29 { get; set; }
        public string data_value_30 { get; set; }
        public string data_value_31 { get; set; }
        public string data_value_32 { get; set; }
        public string data_value_33 { get; set; }
        public string data_value_34 { get; set; }
        public string data_value_35 { get; set; }
        public string data_value_36 { get; set; }
        public string data_value_37 { get; set; }
        public string data_value_38 { get; set; }
        public string data_value_39 { get; set; }
        public string data_value_40 { get; set; }
        public DateTime clm_date_time { get; set; }
        public string clm_user { get; set; }

    }
    public class IOT_DEVICE_EDC_124
    {

        public int id { get; set; }
        public string device_id { get; set; }
        public string data_value_01 { get; set; }
        public string data_value_02 { get; set; }
        public string data_value_03 { get; set; }
        public string data_value_04 { get; set; }
        public string data_value_05 { get; set; }
        public string data_value_06 { get; set; }
        public string data_value_07 { get; set; }
        public string data_value_08 { get; set; }
        public string data_value_09 { get; set; }
        public string data_value_10 { get; set; }
        public string data_value_11 { get; set; }
        public string data_value_12 { get; set; }
        public string data_value_13 { get; set; }
        public string data_value_14 { get; set; }
        public string data_value_15 { get; set; }
        public string data_value_16 { get; set; }
        public string data_value_17 { get; set; }
        public string data_value_18 { get; set; }
        public string data_value_19 { get; set; }
        public string data_value_20 { get; set; }
        public string data_value_21 { get; set; }
        public string data_value_22 { get; set; }
        public string data_value_23 { get; set; }
        public string data_value_24 { get; set; }
        public string data_value_25 { get; set; }
        public string data_value_26 { get; set; }
        public string data_value_27 { get; set; }
        public string data_value_28 { get; set; }
        public string data_value_29 { get; set; }
        public string data_value_30 { get; set; }
        public string data_value_31 { get; set; }
        public string data_value_32 { get; set; }
        public string data_value_33 { get; set; }
        public string data_value_34 { get; set; }
        public string data_value_35 { get; set; }
        public string data_value_36 { get; set; }
        public string data_value_37 { get; set; }
        public string data_value_38 { get; set; }
        public string data_value_39 { get; set; }
        public string data_value_40 { get; set; }
        public DateTime clm_date_time { get; set; }
        public string clm_user { get; set; }

    }
    public class IOT_DEVICE_EDC_125
    {

        public int id { get; set; }
        public string device_id { get; set; }
        public string data_value_01 { get; set; }
        public string data_value_02 { get; set; }
        public string data_value_03 { get; set; }
        public string data_value_04 { get; set; }
        public string data_value_05 { get; set; }
        public string data_value_06 { get; set; }
        public string data_value_07 { get; set; }
        public string data_value_08 { get; set; }
        public string data_value_09 { get; set; }
        public string data_value_10 { get; set; }
        public string data_value_11 { get; set; }
        public string data_value_12 { get; set; }
        public string data_value_13 { get; set; }
        public string data_value_14 { get; set; }
        public string data_value_15 { get; set; }
        public string data_value_16 { get; set; }
        public string data_value_17 { get; set; }
        public string data_value_18 { get; set; }
        public string data_value_19 { get; set; }
        public string data_value_20 { get; set; }
        public string data_value_21 { get; set; }
        public string data_value_22 { get; set; }
        public string data_value_23 { get; set; }
        public string data_value_24 { get; set; }
        public string data_value_25 { get; set; }
        public string data_value_26 { get; set; }
        public string data_value_27 { get; set; }
        public string data_value_28 { get; set; }
        public string data_value_29 { get; set; }
        public string data_value_30 { get; set; }
        public string data_value_31 { get; set; }
        public string data_value_32 { get; set; }
        public string data_value_33 { get; set; }
        public string data_value_34 { get; set; }
        public string data_value_35 { get; set; }
        public string data_value_36 { get; set; }
        public string data_value_37 { get; set; }
        public string data_value_38 { get; set; }
        public string data_value_39 { get; set; }
        public string data_value_40 { get; set; }
        public DateTime clm_date_time { get; set; }
        public string clm_user { get; set; }

    }
    public class IOT_DEVICE_EDC_126
    {

        public int id { get; set; }
        public string device_id { get; set; }
        public string data_value_01 { get; set; }
        public string data_value_02 { get; set; }
        public string data_value_03 { get; set; }
        public string data_value_04 { get; set; }
        public string data_value_05 { get; set; }
        public string data_value_06 { get; set; }
        public string data_value_07 { get; set; }
        public string data_value_08 { get; set; }
        public string data_value_09 { get; set; }
        public string data_value_10 { get; set; }
        public string data_value_11 { get; set; }
        public string data_value_12 { get; set; }
        public string data_value_13 { get; set; }
        public string data_value_14 { get; set; }
        public string data_value_15 { get; set; }
        public string data_value_16 { get; set; }
        public string data_value_17 { get; set; }
        public string data_value_18 { get; set; }
        public string data_value_19 { get; set; }
        public string data_value_20 { get; set; }
        public string data_value_21 { get; set; }
        public string data_value_22 { get; set; }
        public string data_value_23 { get; set; }
        public string data_value_24 { get; set; }
        public string data_value_25 { get; set; }
        public string data_value_26 { get; set; }
        public string data_value_27 { get; set; }
        public string data_value_28 { get; set; }
        public string data_value_29 { get; set; }
        public string data_value_30 { get; set; }
        public string data_value_31 { get; set; }
        public string data_value_32 { get; set; }
        public string data_value_33 { get; set; }
        public string data_value_34 { get; set; }
        public string data_value_35 { get; set; }
        public string data_value_36 { get; set; }
        public string data_value_37 { get; set; }
        public string data_value_38 { get; set; }
        public string data_value_39 { get; set; }
        public string data_value_40 { get; set; }
        public DateTime clm_date_time { get; set; }
        public string clm_user { get; set; }

    }
    public class IOT_DEVICE_EDC_127
    {

        public int id { get; set; }
        public string device_id { get; set; }
        public string data_value_01 { get; set; }
        public string data_value_02 { get; set; }
        public string data_value_03 { get; set; }
        public string data_value_04 { get; set; }
        public string data_value_05 { get; set; }
        public string data_value_06 { get; set; }
        public string data_value_07 { get; set; }
        public string data_value_08 { get; set; }
        public string data_value_09 { get; set; }
        public string data_value_10 { get; set; }
        public string data_value_11 { get; set; }
        public string data_value_12 { get; set; }
        public string data_value_13 { get; set; }
        public string data_value_14 { get; set; }
        public string data_value_15 { get; set; }
        public string data_value_16 { get; set; }
        public string data_value_17 { get; set; }
        public string data_value_18 { get; set; }
        public string data_value_19 { get; set; }
        public string data_value_20 { get; set; }
        public string data_value_21 { get; set; }
        public string data_value_22 { get; set; }
        public string data_value_23 { get; set; }
        public string data_value_24 { get; set; }
        public string data_value_25 { get; set; }
        public string data_value_26 { get; set; }
        public string data_value_27 { get; set; }
        public string data_value_28 { get; set; }
        public string data_value_29 { get; set; }
        public string data_value_30 { get; set; }
        public string data_value_31 { get; set; }
        public string data_value_32 { get; set; }
        public string data_value_33 { get; set; }
        public string data_value_34 { get; set; }
        public string data_value_35 { get; set; }
        public string data_value_36 { get; set; }
        public string data_value_37 { get; set; }
        public string data_value_38 { get; set; }
        public string data_value_39 { get; set; }
        public string data_value_40 { get; set; }
        public DateTime clm_date_time { get; set; }
        public string clm_user { get; set; }

    }
    public class IOT_DEVICE_EDC_128
    {

        public int id { get; set; }
        public string device_id { get; set; }
        public string data_value_01 { get; set; }
        public string data_value_02 { get; set; }
        public string data_value_03 { get; set; }
        public string data_value_04 { get; set; }
        public string data_value_05 { get; set; }
        public string data_value_06 { get; set; }
        public string data_value_07 { get; set; }
        public string data_value_08 { get; set; }
        public string data_value_09 { get; set; }
        public string data_value_10 { get; set; }
        public string data_value_11 { get; set; }
        public string data_value_12 { get; set; }
        public string data_value_13 { get; set; }
        public string data_value_14 { get; set; }
        public string data_value_15 { get; set; }
        public string data_value_16 { get; set; }
        public string data_value_17 { get; set; }
        public string data_value_18 { get; set; }
        public string data_value_19 { get; set; }
        public string data_value_20 { get; set; }
        public string data_value_21 { get; set; }
        public string data_value_22 { get; set; }
        public string data_value_23 { get; set; }
        public string data_value_24 { get; set; }
        public string data_value_25 { get; set; }
        public string data_value_26 { get; set; }
        public string data_value_27 { get; set; }
        public string data_value_28 { get; set; }
        public string data_value_29 { get; set; }
        public string data_value_30 { get; set; }
        public string data_value_31 { get; set; }
        public string data_value_32 { get; set; }
        public string data_value_33 { get; set; }
        public string data_value_34 { get; set; }
        public string data_value_35 { get; set; }
        public string data_value_36 { get; set; }
        public string data_value_37 { get; set; }
        public string data_value_38 { get; set; }
        public string data_value_39 { get; set; }
        public string data_value_40 { get; set; }
        public DateTime clm_date_time { get; set; }
        public string clm_user { get; set; }

    }

}
