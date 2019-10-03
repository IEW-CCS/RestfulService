using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Restful
{

    //使用下列範例中所示的資料合約，新增複合型別至服務作業。
    [DataContract]
    public class CompositeType
    {
        bool boolValue = true;
        string stringValue = "Hello ";

        [DataMember]
        public bool BoolValue
        {
            get { return boolValue; }
            set { boolValue = value; }
        }

        [DataMember]
        public string StringValue
        {
            get { return stringValue; }
            set { stringValue = value; }
        }
    }

    [DataContract]
    public class CCS_Online_Status
    {
        [DataMember]
        public string status { get; set; }
    }

    [DataContract]
    public class CCS_Gateway_List
    {
        [DataMember]
        public List<CCS_Gateway> gateway_list = new List<CCS_Gateway>();

    }

    [DataContract]
    public class CCS_Gateway
    {
        [DataMember]
        public string status { get; set; }

        [DataMember]
        public string gateway_id { get; set; }

        [DataMember]
        public string device_id { get; set; }

        public CCS_Gateway()
        {
            status = "";
            gateway_id = "";
            device_id = "";
        }
    }

    [DataContract]
    public class CCS_Device_Detail_List
    {
        [DataMember]
        public List<CCS_Device_Detail> dvd_list = new List<CCS_Device_Detail>();
    }


    [DataContract]
    public class CCS_Device_Detail
    {
        [DataMember]
        public string gateway_id { get; set; }

        [DataMember]
        public string device_id { get; set; }

        [DataMember]
        public string device_type { get; set; }

        [DataMember]
        public string virtual_flag { get; set; }

        [DataMember]
        public string plc_ip { get; set; }

        [DataMember]
        public string plc_port { get; set; }

        [DataMember]
        public string device_status { get; set; }

        [DataMember]
        public string iotclient_status { get; set; }

        [DataMember]
        public string hb_status { get; set; }

        [DataMember]
        public string device_location { get; set; }

        [DataMember]
        public string last_edc_time { get; set; }

        [DataMember]
        public string hb_report_time { get; set; }

        [DataMember]
        public string last_alarm_code { get; set; }

        [DataMember]
        public string last_alarm_app { get; set; }

        [DataMember]
        public string last_alarm_message { get; set; }

        [DataMember]
        public string last_alarm_datetime { get; set; }


        public CCS_Device_Detail()
        {
            gateway_id = "";
            device_id = "";
            device_type = "";
            virtual_flag = "";
            plc_ip = "";
            plc_port = "";
            device_status = "";
            iotclient_status = "";
            hb_status = "";
            device_location = "";
            last_edc_time = "";
            hb_report_time = "";
            last_alarm_code = "";
            last_alarm_app = "";
            last_alarm_message = "";
            last_alarm_datetime = "";
        }

    }

    [DataContract]
    public class CCS_ChartItem_List
    {
        [DataMember]
        public List<CCS_Device_Item> device_item_list = new List<CCS_Device_Item>();
    }

    [DataContract]
    public class CCS_Device_Item
    {
        [DataMember]
        public string device_id { get; set; }

        [DataMember]
        public List<CCS_ChartItem> item_list = new List<CCS_ChartItem>();
    }

    [DataContract]
    public class CCS_ChartItem
    {
        [DataMember]
        public string item_name { get; set; }

        [DataMember]
        public string chart_type { get; set; }


        public CCS_ChartItem()
        {
            item_name = "";
            chart_type = "";
        }

        public CCS_ChartItem(string item, string type)
        {
            item_name = item;
            chart_type = type;
        }
    }


    [DataContract]
    public class CCS_Chart_Info_Req
    {
        [DataMember]
        public string device_id { get; set; }

        [DataMember]
        public string chart_name { get; set; }

        [DataMember]
        public string get_count { get; set; }

        [DataMember]
        public string start_time { get; set; }

        [DataMember]
        public string end_time { get; set; }
    }

    [DataContract]
    public class CCS_Chart_Body
    {


        [DataMember]
        public string X_asix { get; set; }

        [DataMember]
        public string Y_asix { get; set; }

        public CCS_Chart_Body(string Y, string X)
        {
            X_asix = X;
            Y_asix = Y;
        }

    }

    [DataContract]
    public class CCS_Chart_Info_Reply
    {
        [DataMember]
        public string device_id { get; set; }

        [DataMember]
        public List<CCS_Chart_Body> data_list = new List<CCS_Chart_Body>();

    }

    [DataContract]
    public class CCS_Alarm_List
    {
        [DataMember]
        public List<CCS_Alarm> alarm_list = new List<CCS_Alarm>();
    }

    [DataContract]
    public class CCS_Alarm
    {
        [DataMember]
        public string GatewayID { get; set; }

        [DataMember]
        public string DeviceID { get; set; }

        [DataMember]
        public string AlarmCode { get; set; }

        [DataMember]
        public string AlarmLevel { get; set; }

        [DataMember]
        public string AlarmApp { get; set; }

        [DataMember]
        public string DateTime { get; set; }

        [DataMember]
        public string AlarmDesc { get; set; }
    }

    [DataContract]
    public class BLEDataItem
    {
        [DataMember]
        public string DataName { get; set; }

        [DataMember]
        public string DataType { get; set; }
    }

    [DataContract]
    public class BLECharacteristicData
    {
        [DataMember]
        public string UUID { get; set; }

        [DataMember]
        public List<BLEDataItem> ItemList = new List<BLEDataItem>();
    }

    [DataContract]
    public class BLEProfile
    {
        [DataMember]
        public string BLECategory { get; set; }

        [DataMember]
        public string BLEName { get; set; }

        [DataMember]
        public string BLEDescription { get; set; }

        [DataMember]
        public string ServiceUUID { get; set; }

        [DataMember]
        public List<BLECharacteristicData> CharacteristicUUID = new List<BLECharacteristicData>();

        [DataMember]
        public List<BLECharacteristicData> ConfigParameterList = new List<BLECharacteristicData>();

        [DataMember]
        public string ProfileCreateTime { get; set; }
    }

    [DataContract]
    public class BLEProfileList
    {
        [DataMember]
        public List<BLEProfile> profile_list = new List<BLEProfile>();
    }





}
