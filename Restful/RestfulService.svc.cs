using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using NLog;
using System.IO;
using Newtonsoft.Json;

namespace Restful
{

    // 注意: 您可以使用 [重構] 功能表上的 [重新命名] 命令同時變更程式碼、svc 和組態檔中的類別名稱 "Service1"。
    // 注意: 若要啟動 WCF 測試用戶端以便測試此服務，請在 [方案總管] 中選取 Service1.svc 或 Service1.svc.cs，然後開始偵錯。

    public class RestfulService :  IRestfulService
    { 

        private static string configpath = Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "setting/system.xml");
        private static string simudatapath = Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "simulation_data");
        public static Logger _logger = LogManager.GetCurrentClassLogger();
        public static Config _config = new Config(configpath);
        private static readonly Random getrandom = new Random();


        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }

        //---- GET/ GetwayList Info 
        public CCS_Gateway_List GetGatewayList()
        {
            CCS_Gateway_List gatewayList = new CCS_Gateway_List();
            gatewayList.gateway_list.Clear();
            try
            {
                
                string providername = _config.GetConfig("My_SQL", "providername");
                string connection_string = _config.GetConfig("My_SQL", "connection_string");
                using (IOT_DbContext db = new IOT_DbContext(providername, connection_string))
                {
                    var _Device = db.IOT_Device.AsQueryable().ToList();
                    foreach (IOT_DEVICE Device in _Device)
                    {
                        CCS_Gateway tmp = new CCS_Gateway();
                        tmp.gateway_id = Device.gateway_id;
                        tmp.device_id = Device.device_id;
                        tmp.status = Device.status;
                        gatewayList.gateway_list.Add(tmp);
                    }
                }

                _logger.Info(string.Format("Handle Service CCS_Gateway_List Get Gateways Count : {0}", gatewayList.gateway_list.Count()));
                return gatewayList;
            }
            catch (Exception ex)
            {
                _logger.Error(string.Format("Handle Service CCS_Gateway_List Error, Msg : {0}", ex.Message));
                return new CCS_Gateway_List();
            }


        }

        public CCS_Device_Detail GetDeviceDetail(string device_id)
        {
            CCS_Device_Detail DeviceDetail = new CCS_Device_Detail();

            try
            {
                string providername = _config.GetConfig("My_SQL", "providername");
                string connection_string = _config.GetConfig("My_SQL", "connection_string");
                using (IOT_DbContext db = new IOT_DbContext(providername, connection_string))
                {
                    var _Device = db.IOT_Device.AsQueryable().Where(o => o.device_id.Equals(device_id)).FirstOrDefault();
                    if (_Device != null)
                    {
                        DeviceDetail.gateway_id = _Device.gateway_id;
                        DeviceDetail.device_id = _Device.device_id;
                        DeviceDetail.device_type = _Device.device_type;
                        DeviceDetail.plc_ip = _Device.plc_ip_address;
                        DeviceDetail.plc_port = _Device.plc_port_id;
                        DeviceDetail.device_status = _Device.status;
                        DeviceDetail.device_location = _Device.location;
                    }
                    else
                    {
                        _logger.Error(string.Format("Handle Service CCS_Device_Detail/{0} Error, Not Get Device ID ", device_id));
                    }
                }
                return DeviceDetail;

            }
            catch (Exception ex)
            {
                _logger.Error(string.Format("Handle Service CCS_Device_Detail/{0} Error, Msg : {1}", device_id, ex.Message));
                return new CCS_Device_Detail();
            }
        }

        public CCS_Device_Item GetChartItemList(string device_id)
        {
            CCS_Device_Item DeviceChart = new CCS_Device_Item();
            DeviceChart.device_id = device_id;

            try
            {
                string providername = _config.GetConfig("My_SQL", "providername");
                string connection_string = _config.GetConfig("My_SQL", "connection_string");
                using (IOT_DbContext db = new IOT_DbContext(providername, connection_string))
                {
                    var _EDC_Label = db.IOT_Device_EDC_Label.AsQueryable().Where(o => o.device_id.Equals(device_id)).OrderBy(p => p.data_index).ToList();
                    foreach (IOT_DEVICE_EDC_LABEL edclabel in _EDC_Label)
                    {
                        DeviceChart.item_list.Add(new CCS_ChartItem(edclabel.data_name, "0"));
                    }
                }

                return DeviceChart;
            }
            catch (Exception ex)
            {
                _logger.Error(string.Format("Handle Service CCS_Chart_Item_List/{0} Error, Msg : {1}", device_id, ex.Message));
                return new CCS_Device_Item();
            }
        }

        public CCS_Chart_Info_Reply PostDeviceDetail(CCS_Chart_Info_Req info)
        {
            CCS_Chart_Info_Reply replydata = new CCS_Chart_Info_Reply();
            replydata.device_id = info.device_id;

            try
            {
                string providername = _config.GetConfig("My_SQL", "providername");
                string connection_string = _config.GetConfig("My_SQL", "connection_string");
                using (IOT_DbContext db = new IOT_DbContext(providername, connection_string))
                {
                    var _Device = db.IOT_Device.AsQueryable().Where(o => o.device_id.Equals(info.device_id)).FirstOrDefault();
                    if (_Device == null)
                    {
                        return new CCS_Chart_Info_Reply();
                    }
                    else
                    {
                        var _EDC_Label = db.IOT_Device_EDC_Label.AsQueryable().Where(o => o.device_id.Equals(info.device_id) && o.data_name.Equals(info.chart_name)).FirstOrDefault();
                        if (_EDC_Label == null)
                        {
                            return new CCS_Chart_Info_Reply();
                        }

                        int device_no = _Device.device_no;
                        string edc_no = string.Concat("data_value_", _EDC_Label.data_index.ToString("00"));

                        switch (device_no)
                        {
                            case 1:
                                var EDC001 = db.IOT_DEVICE_EDC_001.AsQueryable().Where(o => o.device_id.Equals(info.device_id)).OrderBy(p => p.clm_date_time).ToList();
                                var Val001 = EDC001.Select(o => new CCS_Chart_Body(o.GetPropertyValue(edc_no).ToString(), ((DateTime)o.GetPropertyValue("clm_date_time")).ToString("yyyyMMddhhmmss"))).ToList();
                                Val001.ForEach(i => replydata.data_list.Add(i));
                                break;

                            case 2:
                                var EDC002 = db.IOT_DEVICE_EDC_002.AsQueryable().Where(o => o.device_id.Equals(info.device_id)).OrderBy(p => p.clm_date_time).ToList();
                                var Val002 = EDC002.Select(o => new CCS_Chart_Body(o.GetPropertyValue(edc_no).ToString(), ((DateTime)o.GetPropertyValue("clm_date_time")).ToString("yyyyMMddhhmmss"))).ToList();
                                Val002.ForEach(i => replydata.data_list.Add(i));
                                break;

                            case 3:
                                var EDC003 = db.IOT_DEVICE_EDC_003.AsQueryable().Where(o => o.device_id.Equals(info.device_id)).OrderBy(p => p.clm_date_time).ToList();
                                var Val003 = EDC003.Select(o => new CCS_Chart_Body(o.GetPropertyValue(edc_no).ToString(), ((DateTime)o.GetPropertyValue("clm_date_time")).ToString("yyyyMMddhhmmss"))).ToList();
                                Val003.ForEach(i => replydata.data_list.Add(i));
                                break;

                            case 4:
                                var EDC004 = db.IOT_DEVICE_EDC_004.AsQueryable().Where(o => o.device_id.Equals(info.device_id)).OrderBy(p => p.clm_date_time).ToList();
                                var Val004 = EDC004.Select(o => new CCS_Chart_Body(o.GetPropertyValue(edc_no).ToString(), ((DateTime)o.GetPropertyValue("clm_date_time")).ToString("yyyyMMddhhmmss"))).ToList();
                                Val004.ForEach(i => replydata.data_list.Add(i));
                                break;

                            case 5:
                                var EDC005 = db.IOT_DEVICE_EDC_005.AsQueryable().Where(o => o.device_id.Equals(info.device_id)).OrderBy(p => p.clm_date_time).ToList();
                                var Val005 = EDC005.Select(o => new CCS_Chart_Body(o.GetPropertyValue(edc_no).ToString(), ((DateTime)o.GetPropertyValue("clm_date_time")).ToString("yyyyMMddhhmmss"))).ToList();
                                Val005.ForEach(i => replydata.data_list.Add(i));
                                break;

                            case 6:
                                var EDC006 = db.IOT_DEVICE_EDC_006.AsQueryable().Where(o => o.device_id.Equals(info.device_id)).OrderBy(p => p.clm_date_time).ToList();
                                var Val006 = EDC006.Select(o => new CCS_Chart_Body(o.GetPropertyValue(edc_no).ToString(), ((DateTime)o.GetPropertyValue("clm_date_time")).ToString("yyyyMMddhhmmss"))).ToList();
                                Val006.ForEach(i => replydata.data_list.Add(i));
                                break;

                            case 7:
                                var EDC007 = db.IOT_DEVICE_EDC_007.AsQueryable().Where(o => o.device_id.Equals(info.device_id)).OrderBy(p => p.clm_date_time).ToList();
                                var Val007 = EDC007.Select(o => new CCS_Chart_Body(o.GetPropertyValue(edc_no).ToString(), ((DateTime)o.GetPropertyValue("clm_date_time")).ToString("yyyyMMddhhmmss"))).ToList();
                                Val007.ForEach(i => replydata.data_list.Add(i));
                                break;

                            case 8:
                                var EDC008 = db.IOT_DEVICE_EDC_008.AsQueryable().Where(o => o.device_id.Equals(info.device_id)).OrderBy(p => p.clm_date_time).ToList();
                                var Val008 = EDC008.Select(o => new CCS_Chart_Body(o.GetPropertyValue(edc_no).ToString(), ((DateTime)o.GetPropertyValue("clm_date_time")).ToString("yyyyMMddhhmmss"))).ToList();
                                Val008.ForEach(i => replydata.data_list.Add(i));
                                break;

                            case 9:
                                var EDC009 = db.IOT_DEVICE_EDC_009.AsQueryable().Where(o => o.device_id.Equals(info.device_id)).OrderBy(p => p.clm_date_time).ToList();
                                var Val009 = EDC009.Select(o => new CCS_Chart_Body(o.GetPropertyValue(edc_no).ToString(), ((DateTime)o.GetPropertyValue("clm_date_time")).ToString("yyyyMMddhhmmss"))).ToList();
                                Val009.ForEach(i => replydata.data_list.Add(i));
                                break;

                            case 10:
                                var EDC010 = db.IOT_DEVICE_EDC_010.AsQueryable().Where(o => o.device_id.Equals(info.device_id)).OrderBy(p => p.clm_date_time).ToList();
                                var Val010 = EDC010.Select(o => new CCS_Chart_Body(o.GetPropertyValue(edc_no).ToString(), ((DateTime)o.GetPropertyValue("clm_date_time")).ToString("yyyyMMddhhmmss"))).ToList();
                                Val010.ForEach(i => replydata.data_list.Add(i));
                                break;

                            case 11:
                                var EDC011 = db.IOT_DEVICE_EDC_011.AsQueryable().Where(o => o.device_id.Equals(info.device_id)).OrderBy(p => p.clm_date_time).ToList();
                                var Val011 = EDC011.Select(o => new CCS_Chart_Body(o.GetPropertyValue(edc_no).ToString(), ((DateTime)o.GetPropertyValue("clm_date_time")).ToString("yyyyMMddhhmmss"))).ToList();
                                Val011.ForEach(i => replydata.data_list.Add(i));
                                break;

                            case 12:
                                var EDC012 = db.IOT_DEVICE_EDC_012.AsQueryable().Where(o => o.device_id.Equals(info.device_id)).OrderBy(p => p.clm_date_time).ToList();
                                var Val012 = EDC012.Select(o => new CCS_Chart_Body(o.GetPropertyValue(edc_no).ToString(), ((DateTime)o.GetPropertyValue("clm_date_time")).ToString("yyyyMMddhhmmss"))).ToList();
                                Val012.ForEach(i => replydata.data_list.Add(i));
                                break;

                            case 13:
                                var EDC013 = db.IOT_DEVICE_EDC_013.AsQueryable().Where(o => o.device_id.Equals(info.device_id)).OrderBy(p => p.clm_date_time).ToList();
                                var Val013 = EDC013.Select(o => new CCS_Chart_Body(o.GetPropertyValue(edc_no).ToString(), ((DateTime)o.GetPropertyValue("clm_date_time")).ToString("yyyyMMddhhmmss"))).ToList();
                                Val013.ForEach(i => replydata.data_list.Add(i));
                                break;

                            case 14:
                                var EDC014 = db.IOT_DEVICE_EDC_014.AsQueryable().Where(o => o.device_id.Equals(info.device_id)).OrderBy(p => p.clm_date_time).ToList();
                                var Val014 = EDC014.Select(o => new CCS_Chart_Body(o.GetPropertyValue(edc_no).ToString(), ((DateTime)o.GetPropertyValue("clm_date_time")).ToString("yyyyMMddhhmmss"))).ToList();
                                Val014.ForEach(i => replydata.data_list.Add(i));
                                break;

                            case 15:
                                var EDC015 = db.IOT_DEVICE_EDC_015.AsQueryable().Where(o => o.device_id.Equals(info.device_id)).OrderBy(p => p.clm_date_time).ToList();
                                var Val015 = EDC015.Select(o => new CCS_Chart_Body(o.GetPropertyValue(edc_no).ToString(), ((DateTime)o.GetPropertyValue("clm_date_time")).ToString("yyyyMMddhhmmss"))).ToList();
                                Val015.ForEach(i => replydata.data_list.Add(i));
                                break;

                            case 16:
                                var EDC016 = db.IOT_DEVICE_EDC_016.AsQueryable().Where(o => o.device_id.Equals(info.device_id)).OrderBy(p => p.clm_date_time).ToList();
                                var Val016 = EDC016.Select(o => new CCS_Chart_Body(o.GetPropertyValue(edc_no).ToString(), ((DateTime)o.GetPropertyValue("clm_date_time")).ToString("yyyyMMddhhmmss"))).ToList();
                                Val016.ForEach(i => replydata.data_list.Add(i));
                                break;

                            case 17:
                                var EDC017 = db.IOT_DEVICE_EDC_017.AsQueryable().Where(o => o.device_id.Equals(info.device_id)).OrderBy(p => p.clm_date_time).ToList();
                                var Val017 = EDC017.Select(o => new CCS_Chart_Body(o.GetPropertyValue(edc_no).ToString(), ((DateTime)o.GetPropertyValue("clm_date_time")).ToString("yyyyMMddhhmmss"))).ToList();
                                Val017.ForEach(i => replydata.data_list.Add(i));
                                break;

                            case 18:
                                var EDC018 = db.IOT_DEVICE_EDC_018.AsQueryable().Where(o => o.device_id.Equals(info.device_id)).OrderBy(p => p.clm_date_time).ToList();
                                var Val018 = EDC018.Select(o => new CCS_Chart_Body(o.GetPropertyValue(edc_no).ToString(), ((DateTime)o.GetPropertyValue("clm_date_time")).ToString("yyyyMMddhhmmss"))).ToList();
                                Val018.ForEach(i => replydata.data_list.Add(i));
                                break;

                            case 19:
                                var EDC019 = db.IOT_DEVICE_EDC_019.AsQueryable().Where(o => o.device_id.Equals(info.device_id)).OrderBy(p => p.clm_date_time).ToList();
                                var Val019 = EDC019.Select(o => new CCS_Chart_Body(o.GetPropertyValue(edc_no).ToString(), ((DateTime)o.GetPropertyValue("clm_date_time")).ToString("yyyyMMddhhmmss"))).ToList();
                                Val019.ForEach(i => replydata.data_list.Add(i));
                                break;

                            case 20:
                                var EDC020 = db.IOT_DEVICE_EDC_020.AsQueryable().Where(o => o.device_id.Equals(info.device_id)).OrderBy(p => p.clm_date_time).ToList();
                                var Val020 = EDC020.Select(o => new CCS_Chart_Body(o.GetPropertyValue(edc_no).ToString(), ((DateTime)o.GetPropertyValue("clm_date_time")).ToString("yyyyMMddhhmmss"))).ToList();
                                Val020.ForEach(i => replydata.data_list.Add(i));
                                break;

                            case 21:
                                var EDC021 = db.IOT_DEVICE_EDC_021.AsQueryable().Where(o => o.device_id.Equals(info.device_id)).OrderBy(p => p.clm_date_time).ToList();
                                var Val021 = EDC021.Select(o => new CCS_Chart_Body(o.GetPropertyValue(edc_no).ToString(), ((DateTime)o.GetPropertyValue("clm_date_time")).ToString("yyyyMMddhhmmss"))).ToList();
                                Val021.ForEach(i => replydata.data_list.Add(i));
                                break;

                            case 22:
                                var EDC022 = db.IOT_DEVICE_EDC_022.AsQueryable().Where(o => o.device_id.Equals(info.device_id)).OrderBy(p => p.clm_date_time).ToList();
                                var Val022 = EDC022.Select(o => new CCS_Chart_Body(o.GetPropertyValue(edc_no).ToString(), ((DateTime)o.GetPropertyValue("clm_date_time")).ToString("yyyyMMddhhmmss"))).ToList();
                                Val022.ForEach(i => replydata.data_list.Add(i));
                                break;

                            case 23:
                                var EDC023 = db.IOT_DEVICE_EDC_023.AsQueryable().Where(o => o.device_id.Equals(info.device_id)).OrderBy(p => p.clm_date_time).ToList();
                                var Val023 = EDC023.Select(o => new CCS_Chart_Body(o.GetPropertyValue(edc_no).ToString(), ((DateTime)o.GetPropertyValue("clm_date_time")).ToString("yyyyMMddhhmmss"))).ToList();
                                Val023.ForEach(i => replydata.data_list.Add(i));
                                break;

                            case 24:
                                var EDC024 = db.IOT_DEVICE_EDC_024.AsQueryable().Where(o => o.device_id.Equals(info.device_id)).OrderBy(p => p.clm_date_time).ToList();
                                var Val024 = EDC024.Select(o => new CCS_Chart_Body(o.GetPropertyValue(edc_no).ToString(), ((DateTime)o.GetPropertyValue("clm_date_time")).ToString("yyyyMMddhhmmss"))).ToList();
                                Val024.ForEach(i => replydata.data_list.Add(i));
                                break;

                            case 25:
                                var EDC025 = db.IOT_DEVICE_EDC_025.AsQueryable().Where(o => o.device_id.Equals(info.device_id)).OrderBy(p => p.clm_date_time).ToList();
                                var Val025 = EDC025.Select(o => new CCS_Chart_Body(o.GetPropertyValue(edc_no).ToString(), ((DateTime)o.GetPropertyValue("clm_date_time")).ToString("yyyyMMddhhmmss"))).ToList();
                                Val025.ForEach(i => replydata.data_list.Add(i));
                                break;

                            case 26:
                                var EDC026 = db.IOT_DEVICE_EDC_026.AsQueryable().Where(o => o.device_id.Equals(info.device_id)).OrderBy(p => p.clm_date_time).ToList();
                                var Val026 = EDC026.Select(o => new CCS_Chart_Body(o.GetPropertyValue(edc_no).ToString(), ((DateTime)o.GetPropertyValue("clm_date_time")).ToString("yyyyMMddhhmmss"))).ToList();
                                Val026.ForEach(i => replydata.data_list.Add(i));
                                break;

                            case 27:
                                var EDC027 = db.IOT_DEVICE_EDC_027.AsQueryable().Where(o => o.device_id.Equals(info.device_id)).OrderBy(p => p.clm_date_time).ToList();
                                var Val027 = EDC027.Select(o => new CCS_Chart_Body(o.GetPropertyValue(edc_no).ToString(), ((DateTime)o.GetPropertyValue("clm_date_time")).ToString("yyyyMMddhhmmss"))).ToList();
                                Val027.ForEach(i => replydata.data_list.Add(i));
                                break;

                            case 28:
                                var EDC028 = db.IOT_DEVICE_EDC_028.AsQueryable().Where(o => o.device_id.Equals(info.device_id)).OrderBy(p => p.clm_date_time).ToList();
                                var Val028 = EDC028.Select(o => new CCS_Chart_Body(o.GetPropertyValue(edc_no).ToString(), ((DateTime)o.GetPropertyValue("clm_date_time")).ToString("yyyyMMddhhmmss"))).ToList();
                                Val028.ForEach(i => replydata.data_list.Add(i));
                                break;

                            case 29:
                                var EDC029 = db.IOT_DEVICE_EDC_029.AsQueryable().Where(o => o.device_id.Equals(info.device_id)).OrderBy(p => p.clm_date_time).ToList();
                                var Val029 = EDC029.Select(o => new CCS_Chart_Body(o.GetPropertyValue(edc_no).ToString(), ((DateTime)o.GetPropertyValue("clm_date_time")).ToString("yyyyMMddhhmmss"))).ToList();
                                Val029.ForEach(i => replydata.data_list.Add(i));
                                break;

                            case 30:
                                var EDC030 = db.IOT_DEVICE_EDC_030.AsQueryable().Where(o => o.device_id.Equals(info.device_id)).OrderBy(p => p.clm_date_time).ToList();
                                var Val030 = EDC030.Select(o => new CCS_Chart_Body(o.GetPropertyValue(edc_no).ToString(), ((DateTime)o.GetPropertyValue("clm_date_time")).ToString("yyyyMMddhhmmss"))).ToList();
                                Val030.ForEach(i => replydata.data_list.Add(i));
                                break;

                            case 31:
                                var EDC031 = db.IOT_DEVICE_EDC_031.AsQueryable().Where(o => o.device_id.Equals(info.device_id)).OrderBy(p => p.clm_date_time).ToList();
                                var Val031 = EDC031.Select(o => new CCS_Chart_Body(o.GetPropertyValue(edc_no).ToString(), ((DateTime)o.GetPropertyValue("clm_date_time")).ToString("yyyyMMddhhmmss"))).ToList();
                                Val031.ForEach(i => replydata.data_list.Add(i));
                                break;

                            case 32:
                                var EDC032 = db.IOT_DEVICE_EDC_032.AsQueryable().Where(o => o.device_id.Equals(info.device_id)).OrderBy(p => p.clm_date_time).ToList();
                                var Val032 = EDC032.Select(o => new CCS_Chart_Body(o.GetPropertyValue(edc_no).ToString(), ((DateTime)o.GetPropertyValue("clm_date_time")).ToString("yyyyMMddhhmmss"))).ToList();
                                Val032.ForEach(i => replydata.data_list.Add(i));
                                break;

                            case 33:
                                var EDC033 = db.IOT_DEVICE_EDC_033.AsQueryable().Where(o => o.device_id.Equals(info.device_id)).OrderBy(p => p.clm_date_time).ToList();
                                var Val033 = EDC033.Select(o => new CCS_Chart_Body(o.GetPropertyValue(edc_no).ToString(), ((DateTime)o.GetPropertyValue("clm_date_time")).ToString("yyyyMMddhhmmss"))).ToList();
                                Val033.ForEach(i => replydata.data_list.Add(i));
                                break;

                            case 34:
                                var EDC034 = db.IOT_DEVICE_EDC_034.AsQueryable().Where(o => o.device_id.Equals(info.device_id)).OrderBy(p => p.clm_date_time).ToList();
                                var Val034 = EDC034.Select(o => new CCS_Chart_Body(o.GetPropertyValue(edc_no).ToString(), ((DateTime)o.GetPropertyValue("clm_date_time")).ToString("yyyyMMddhhmmss"))).ToList();
                                Val034.ForEach(i => replydata.data_list.Add(i));
                                break;

                            case 35:
                                var EDC035 = db.IOT_DEVICE_EDC_035.AsQueryable().Where(o => o.device_id.Equals(info.device_id)).OrderBy(p => p.clm_date_time).ToList();
                                var Val035 = EDC035.Select(o => new CCS_Chart_Body(o.GetPropertyValue(edc_no).ToString(), ((DateTime)o.GetPropertyValue("clm_date_time")).ToString("yyyyMMddhhmmss"))).ToList();
                                Val035.ForEach(i => replydata.data_list.Add(i));
                                break;

                            case 36:
                                var EDC036 = db.IOT_DEVICE_EDC_036.AsQueryable().Where(o => o.device_id.Equals(info.device_id)).OrderBy(p => p.clm_date_time).ToList();
                                var Val036 = EDC036.Select(o => new CCS_Chart_Body(o.GetPropertyValue(edc_no).ToString(), ((DateTime)o.GetPropertyValue("clm_date_time")).ToString("yyyyMMddhhmmss"))).ToList();
                                Val036.ForEach(i => replydata.data_list.Add(i));
                                break;

                            case 37:
                                var EDC037 = db.IOT_DEVICE_EDC_037.AsQueryable().Where(o => o.device_id.Equals(info.device_id)).OrderBy(p => p.clm_date_time).ToList();
                                var Val037 = EDC037.Select(o => new CCS_Chart_Body(o.GetPropertyValue(edc_no).ToString(), ((DateTime)o.GetPropertyValue("clm_date_time")).ToString("yyyyMMddhhmmss"))).ToList();
                                Val037.ForEach(i => replydata.data_list.Add(i));
                                break;

                            case 38:
                                var EDC038 = db.IOT_DEVICE_EDC_038.AsQueryable().Where(o => o.device_id.Equals(info.device_id)).OrderBy(p => p.clm_date_time).ToList();
                                var Val038 = EDC038.Select(o => new CCS_Chart_Body(o.GetPropertyValue(edc_no).ToString(), ((DateTime)o.GetPropertyValue("clm_date_time")).ToString("yyyyMMddhhmmss"))).ToList();
                                Val038.ForEach(i => replydata.data_list.Add(i));
                                break;

                            case 39:
                                var EDC039 = db.IOT_DEVICE_EDC_039.AsQueryable().Where(o => o.device_id.Equals(info.device_id)).OrderBy(p => p.clm_date_time).ToList();
                                var Val039 = EDC039.Select(o => new CCS_Chart_Body(o.GetPropertyValue(edc_no).ToString(), ((DateTime)o.GetPropertyValue("clm_date_time")).ToString("yyyyMMddhhmmss"))).ToList();
                                Val039.ForEach(i => replydata.data_list.Add(i));
                                break;

                            case 40:
                                var EDC040 = db.IOT_DEVICE_EDC_040.AsQueryable().Where(o => o.device_id.Equals(info.device_id)).OrderBy(p => p.clm_date_time).ToList();
                                var Val040 = EDC040.Select(o => new CCS_Chart_Body(o.GetPropertyValue(edc_no).ToString(), ((DateTime)o.GetPropertyValue("clm_date_time")).ToString("yyyyMMddhhmmss"))).ToList();
                                Val040.ForEach(i => replydata.data_list.Add(i));
                                break;

                            case 41:
                                var EDC041 = db.IOT_DEVICE_EDC_041.AsQueryable().Where(o => o.device_id.Equals(info.device_id)).OrderBy(p => p.clm_date_time).ToList();
                                var Val041 = EDC041.Select(o => new CCS_Chart_Body(o.GetPropertyValue(edc_no).ToString(), ((DateTime)o.GetPropertyValue("clm_date_time")).ToString("yyyyMMddhhmmss"))).ToList();
                                Val041.ForEach(i => replydata.data_list.Add(i));
                                break;

                            case 42:
                                var EDC042 = db.IOT_DEVICE_EDC_042.AsQueryable().Where(o => o.device_id.Equals(info.device_id)).OrderBy(p => p.clm_date_time).ToList();
                                var Val042 = EDC042.Select(o => new CCS_Chart_Body(o.GetPropertyValue(edc_no).ToString(), ((DateTime)o.GetPropertyValue("clm_date_time")).ToString("yyyyMMddhhmmss"))).ToList();
                                Val042.ForEach(i => replydata.data_list.Add(i));
                                break;

                            case 43:
                                var EDC043 = db.IOT_DEVICE_EDC_043.AsQueryable().Where(o => o.device_id.Equals(info.device_id)).OrderBy(p => p.clm_date_time).ToList();
                                var Val043 = EDC043.Select(o => new CCS_Chart_Body(o.GetPropertyValue(edc_no).ToString(), ((DateTime)o.GetPropertyValue("clm_date_time")).ToString("yyyyMMddhhmmss"))).ToList();
                                Val043.ForEach(i => replydata.data_list.Add(i));
                                break;

                            case 44:
                                var EDC044 = db.IOT_DEVICE_EDC_044.AsQueryable().Where(o => o.device_id.Equals(info.device_id)).OrderBy(p => p.clm_date_time).ToList();
                                var Val044 = EDC044.Select(o => new CCS_Chart_Body(o.GetPropertyValue(edc_no).ToString(), ((DateTime)o.GetPropertyValue("clm_date_time")).ToString("yyyyMMddhhmmss"))).ToList();
                                Val044.ForEach(i => replydata.data_list.Add(i));
                                break;

                            case 45:
                                var EDC045 = db.IOT_DEVICE_EDC_045.AsQueryable().Where(o => o.device_id.Equals(info.device_id)).OrderBy(p => p.clm_date_time).ToList();
                                var Val045 = EDC045.Select(o => new CCS_Chart_Body(o.GetPropertyValue(edc_no).ToString(), ((DateTime)o.GetPropertyValue("clm_date_time")).ToString("yyyyMMddhhmmss"))).ToList();
                                Val045.ForEach(i => replydata.data_list.Add(i));
                                break;

                            case 46:
                                var EDC046 = db.IOT_DEVICE_EDC_046.AsQueryable().Where(o => o.device_id.Equals(info.device_id)).OrderBy(p => p.clm_date_time).ToList();
                                var Val046 = EDC046.Select(o => new CCS_Chart_Body(o.GetPropertyValue(edc_no).ToString(), ((DateTime)o.GetPropertyValue("clm_date_time")).ToString("yyyyMMddhhmmss"))).ToList();
                                Val046.ForEach(i => replydata.data_list.Add(i));
                                break;

                            case 47:
                                var EDC047 = db.IOT_DEVICE_EDC_047.AsQueryable().Where(o => o.device_id.Equals(info.device_id)).OrderBy(p => p.clm_date_time).ToList();
                                var Val047 = EDC047.Select(o => new CCS_Chart_Body(o.GetPropertyValue(edc_no).ToString(), ((DateTime)o.GetPropertyValue("clm_date_time")).ToString("yyyyMMddhhmmss"))).ToList();
                                Val047.ForEach(i => replydata.data_list.Add(i));
                                break;

                            case 48:
                                var EDC048 = db.IOT_DEVICE_EDC_048.AsQueryable().Where(o => o.device_id.Equals(info.device_id)).OrderBy(p => p.clm_date_time).ToList();
                                var Val048 = EDC048.Select(o => new CCS_Chart_Body(o.GetPropertyValue(edc_no).ToString(), ((DateTime)o.GetPropertyValue("clm_date_time")).ToString("yyyyMMddhhmmss"))).ToList();
                                Val048.ForEach(i => replydata.data_list.Add(i));
                                break;

                            case 49:
                                var EDC049 = db.IOT_DEVICE_EDC_049.AsQueryable().Where(o => o.device_id.Equals(info.device_id)).OrderBy(p => p.clm_date_time).ToList();
                                var Val049 = EDC049.Select(o => new CCS_Chart_Body(o.GetPropertyValue(edc_no).ToString(), ((DateTime)o.GetPropertyValue("clm_date_time")).ToString("yyyyMMddhhmmss"))).ToList();
                                Val049.ForEach(i => replydata.data_list.Add(i));
                                break;

                            case 50:
                                var EDC050 = db.IOT_DEVICE_EDC_050.AsQueryable().Where(o => o.device_id.Equals(info.device_id)).OrderBy(p => p.clm_date_time).ToList();
                                var Val050 = EDC050.Select(o => new CCS_Chart_Body(o.GetPropertyValue(edc_no).ToString(), ((DateTime)o.GetPropertyValue("clm_date_time")).ToString("yyyyMMddhhmmss"))).ToList();
                                Val050.ForEach(i => replydata.data_list.Add(i));
                                break;

                            case 51:
                                var EDC051 = db.IOT_DEVICE_EDC_051.AsQueryable().Where(o => o.device_id.Equals(info.device_id)).OrderBy(p => p.clm_date_time).ToList();
                                var Val051 = EDC051.Select(o => new CCS_Chart_Body(o.GetPropertyValue(edc_no).ToString(), ((DateTime)o.GetPropertyValue("clm_date_time")).ToString("yyyyMMddhhmmss"))).ToList();
                                Val051.ForEach(i => replydata.data_list.Add(i));
                                break;

                            case 52:
                                var EDC052 = db.IOT_DEVICE_EDC_052.AsQueryable().Where(o => o.device_id.Equals(info.device_id)).OrderBy(p => p.clm_date_time).ToList();
                                var Val052 = EDC052.Select(o => new CCS_Chart_Body(o.GetPropertyValue(edc_no).ToString(), ((DateTime)o.GetPropertyValue("clm_date_time")).ToString("yyyyMMddhhmmss"))).ToList();
                                Val052.ForEach(i => replydata.data_list.Add(i));
                                break;

                            case 53:
                                var EDC053 = db.IOT_DEVICE_EDC_053.AsQueryable().Where(o => o.device_id.Equals(info.device_id)).OrderBy(p => p.clm_date_time).ToList();
                                var Val053 = EDC053.Select(o => new CCS_Chart_Body(o.GetPropertyValue(edc_no).ToString(), ((DateTime)o.GetPropertyValue("clm_date_time")).ToString("yyyyMMddhhmmss"))).ToList();
                                Val053.ForEach(i => replydata.data_list.Add(i));
                                break;

                            case 54:
                                var EDC054 = db.IOT_DEVICE_EDC_054.AsQueryable().Where(o => o.device_id.Equals(info.device_id)).OrderBy(p => p.clm_date_time).ToList();
                                var Val054 = EDC054.Select(o => new CCS_Chart_Body(o.GetPropertyValue(edc_no).ToString(), ((DateTime)o.GetPropertyValue("clm_date_time")).ToString("yyyyMMddhhmmss"))).ToList();
                                Val054.ForEach(i => replydata.data_list.Add(i));
                                break;

                            case 55:
                                var EDC055 = db.IOT_DEVICE_EDC_055.AsQueryable().Where(o => o.device_id.Equals(info.device_id)).OrderBy(p => p.clm_date_time).ToList();
                                var Val055 = EDC055.Select(o => new CCS_Chart_Body(o.GetPropertyValue(edc_no).ToString(), ((DateTime)o.GetPropertyValue("clm_date_time")).ToString("yyyyMMddhhmmss"))).ToList();
                                Val055.ForEach(i => replydata.data_list.Add(i));
                                break;

                            case 56:
                                var EDC056 = db.IOT_DEVICE_EDC_056.AsQueryable().Where(o => o.device_id.Equals(info.device_id)).OrderBy(p => p.clm_date_time).ToList();
                                var Val056 = EDC056.Select(o => new CCS_Chart_Body(o.GetPropertyValue(edc_no).ToString(), ((DateTime)o.GetPropertyValue("clm_date_time")).ToString("yyyyMMddhhmmss"))).ToList();
                                Val056.ForEach(i => replydata.data_list.Add(i));
                                break;

                            case 57:
                                var EDC057 = db.IOT_DEVICE_EDC_057.AsQueryable().Where(o => o.device_id.Equals(info.device_id)).OrderBy(p => p.clm_date_time).ToList();
                                var Val057 = EDC057.Select(o => new CCS_Chart_Body(o.GetPropertyValue(edc_no).ToString(), ((DateTime)o.GetPropertyValue("clm_date_time")).ToString("yyyyMMddhhmmss"))).ToList();
                                Val057.ForEach(i => replydata.data_list.Add(i));
                                break;

                            case 58:
                                var EDC058 = db.IOT_DEVICE_EDC_058.AsQueryable().Where(o => o.device_id.Equals(info.device_id)).OrderBy(p => p.clm_date_time).ToList();
                                var Val058 = EDC058.Select(o => new CCS_Chart_Body(o.GetPropertyValue(edc_no).ToString(), ((DateTime)o.GetPropertyValue("clm_date_time")).ToString("yyyyMMddhhmmss"))).ToList();
                                Val058.ForEach(i => replydata.data_list.Add(i));
                                break;

                            case 59:
                                var EDC059 = db.IOT_DEVICE_EDC_059.AsQueryable().Where(o => o.device_id.Equals(info.device_id)).OrderBy(p => p.clm_date_time).ToList();
                                var Val059 = EDC059.Select(o => new CCS_Chart_Body(o.GetPropertyValue(edc_no).ToString(), ((DateTime)o.GetPropertyValue("clm_date_time")).ToString("yyyyMMddhhmmss"))).ToList();
                                Val059.ForEach(i => replydata.data_list.Add(i));
                                break;


                            case 60:
                                var EDC060 = db.IOT_DEVICE_EDC_060.AsQueryable().Where(o => o.device_id.Equals(info.device_id)).OrderBy(p => p.clm_date_time).ToList();
                                var Val060 = EDC060.Select(o => new CCS_Chart_Body(o.GetPropertyValue(edc_no).ToString(), ((DateTime)o.GetPropertyValue("clm_date_time")).ToString("yyyyMMddhhmmss"))).ToList();
                                Val060.ForEach(i => replydata.data_list.Add(i));
                                break;

                            case 61:
                                var EDC061 = db.IOT_DEVICE_EDC_061.AsQueryable().Where(o => o.device_id.Equals(info.device_id)).OrderBy(p => p.clm_date_time).ToList();
                                var Val061 = EDC061.Select(o => new CCS_Chart_Body(o.GetPropertyValue(edc_no).ToString(), ((DateTime)o.GetPropertyValue("clm_date_time")).ToString("yyyyMMddhhmmss"))).ToList();
                                Val061.ForEach(i => replydata.data_list.Add(i));
                                break;

                            case 62:
                                var EDC062 = db.IOT_DEVICE_EDC_062.AsQueryable().Where(o => o.device_id.Equals(info.device_id)).OrderBy(p => p.clm_date_time).ToList();
                                var Val062 = EDC062.Select(o => new CCS_Chart_Body(o.GetPropertyValue(edc_no).ToString(), ((DateTime)o.GetPropertyValue("clm_date_time")).ToString("yyyyMMddhhmmss"))).ToList();
                                Val062.ForEach(i => replydata.data_list.Add(i));
                                break;

                            case 63:
                                var EDC063 = db.IOT_DEVICE_EDC_063.AsQueryable().Where(o => o.device_id.Equals(info.device_id)).OrderBy(p => p.clm_date_time).ToList();
                                var Val063 = EDC063.Select(o => new CCS_Chart_Body(o.GetPropertyValue(edc_no).ToString(), ((DateTime)o.GetPropertyValue("clm_date_time")).ToString("yyyyMMddhhmmss"))).ToList();
                                Val063.ForEach(i => replydata.data_list.Add(i));
                                break;

                            case 64:
                                var EDC064 = db.IOT_DEVICE_EDC_064.AsQueryable().Where(o => o.device_id.Equals(info.device_id)).OrderBy(p => p.clm_date_time).ToList();
                                var Val064 = EDC064.Select(o => new CCS_Chart_Body(o.GetPropertyValue(edc_no).ToString(), ((DateTime)o.GetPropertyValue("clm_date_time")).ToString("yyyyMMddhhmmss"))).ToList();
                                Val064.ForEach(i => replydata.data_list.Add(i));
                                break;

                            case 65:
                                var EDC065 = db.IOT_DEVICE_EDC_065.AsQueryable().Where(o => o.device_id.Equals(info.device_id)).OrderBy(p => p.clm_date_time).ToList();
                                var Val065 = EDC065.Select(o => new CCS_Chart_Body(o.GetPropertyValue(edc_no).ToString(), ((DateTime)o.GetPropertyValue("clm_date_time")).ToString("yyyyMMddhhmmss"))).ToList();
                                Val065.ForEach(i => replydata.data_list.Add(i));
                                break;

                            case 66:
                                var EDC066 = db.IOT_DEVICE_EDC_066.AsQueryable().Where(o => o.device_id.Equals(info.device_id)).OrderBy(p => p.clm_date_time).ToList();
                                var Val066 = EDC066.Select(o => new CCS_Chart_Body(o.GetPropertyValue(edc_no).ToString(), ((DateTime)o.GetPropertyValue("clm_date_time")).ToString("yyyyMMddhhmmss"))).ToList();
                                Val066.ForEach(i => replydata.data_list.Add(i));
                                break;

                            case 67:
                                var EDC067 = db.IOT_DEVICE_EDC_067.AsQueryable().Where(o => o.device_id.Equals(info.device_id)).OrderBy(p => p.clm_date_time).ToList();
                                var Val067 = EDC067.Select(o => new CCS_Chart_Body(o.GetPropertyValue(edc_no).ToString(), ((DateTime)o.GetPropertyValue("clm_date_time")).ToString("yyyyMMddhhmmss"))).ToList();
                                Val067.ForEach(i => replydata.data_list.Add(i));
                                break;

                            case 68:
                                var EDC068 = db.IOT_DEVICE_EDC_068.AsQueryable().Where(o => o.device_id.Equals(info.device_id)).OrderBy(p => p.clm_date_time).ToList();
                                var Val068 = EDC068.Select(o => new CCS_Chart_Body(o.GetPropertyValue(edc_no).ToString(), ((DateTime)o.GetPropertyValue("clm_date_time")).ToString("yyyyMMddhhmmss"))).ToList();
                                Val068.ForEach(i => replydata.data_list.Add(i));
                                break;

                            case 69:
                                var EDC069 = db.IOT_DEVICE_EDC_069.AsQueryable().Where(o => o.device_id.Equals(info.device_id)).OrderBy(p => p.clm_date_time).ToList();
                                var Val069 = EDC069.Select(o => new CCS_Chart_Body(o.GetPropertyValue(edc_no).ToString(), ((DateTime)o.GetPropertyValue("clm_date_time")).ToString("yyyyMMddhhmmss"))).ToList();
                                Val069.ForEach(i => replydata.data_list.Add(i));
                                break;

                            case 70:
                                var EDC070 = db.IOT_DEVICE_EDC_070.AsQueryable().Where(o => o.device_id.Equals(info.device_id)).OrderBy(p => p.clm_date_time).ToList();
                                var Val070 = EDC070.Select(o => new CCS_Chart_Body(o.GetPropertyValue(edc_no).ToString(), ((DateTime)o.GetPropertyValue("clm_date_time")).ToString("yyyyMMddhhmmss"))).ToList();
                                Val070.ForEach(i => replydata.data_list.Add(i));
                                break;

                            case 71:
                                var EDC071 = db.IOT_DEVICE_EDC_071.AsQueryable().Where(o => o.device_id.Equals(info.device_id)).OrderBy(p => p.clm_date_time).ToList();
                                var Val071 = EDC071.Select(o => new CCS_Chart_Body(o.GetPropertyValue(edc_no).ToString(), ((DateTime)o.GetPropertyValue("clm_date_time")).ToString("yyyyMMddhhmmss"))).ToList();
                                Val071.ForEach(i => replydata.data_list.Add(i));
                                break;

                            case 72:
                                var EDC072 = db.IOT_DEVICE_EDC_072.AsQueryable().Where(o => o.device_id.Equals(info.device_id)).OrderBy(p => p.clm_date_time).ToList();
                                var Val072 = EDC072.Select(o => new CCS_Chart_Body(o.GetPropertyValue(edc_no).ToString(), ((DateTime)o.GetPropertyValue("clm_date_time")).ToString("yyyyMMddhhmmss"))).ToList();
                                Val072.ForEach(i => replydata.data_list.Add(i));
                                break;

                            case 73:
                                var EDC073 = db.IOT_DEVICE_EDC_073.AsQueryable().Where(o => o.device_id.Equals(info.device_id)).OrderBy(p => p.clm_date_time).ToList();
                                var Val073 = EDC073.Select(o => new CCS_Chart_Body(o.GetPropertyValue(edc_no).ToString(), ((DateTime)o.GetPropertyValue("clm_date_time")).ToString("yyyyMMddhhmmss"))).ToList();
                                Val073.ForEach(i => replydata.data_list.Add(i));
                                break;

                            case 74:
                                var EDC074 = db.IOT_DEVICE_EDC_074.AsQueryable().Where(o => o.device_id.Equals(info.device_id)).OrderBy(p => p.clm_date_time).ToList();
                                var Val074 = EDC074.Select(o => new CCS_Chart_Body(o.GetPropertyValue(edc_no).ToString(), ((DateTime)o.GetPropertyValue("clm_date_time")).ToString("yyyyMMddhhmmss"))).ToList();
                                Val074.ForEach(i => replydata.data_list.Add(i));
                                break;

                            case 75:
                                var EDC075 = db.IOT_DEVICE_EDC_075.AsQueryable().Where(o => o.device_id.Equals(info.device_id)).OrderBy(p => p.clm_date_time).ToList();
                                var Val075 = EDC075.Select(o => new CCS_Chart_Body(o.GetPropertyValue(edc_no).ToString(), ((DateTime)o.GetPropertyValue("clm_date_time")).ToString("yyyyMMddhhmmss"))).ToList();
                                Val075.ForEach(i => replydata.data_list.Add(i));
                                break;

                            case 76:
                                var EDC076 = db.IOT_DEVICE_EDC_076.AsQueryable().Where(o => o.device_id.Equals(info.device_id)).OrderBy(p => p.clm_date_time).ToList();
                                var Val076 = EDC076.Select(o => new CCS_Chart_Body(o.GetPropertyValue(edc_no).ToString(), ((DateTime)o.GetPropertyValue("clm_date_time")).ToString("yyyyMMddhhmmss"))).ToList();
                                Val076.ForEach(i => replydata.data_list.Add(i));
                                break;

                            case 77:
                                var EDC077 = db.IOT_DEVICE_EDC_077.AsQueryable().Where(o => o.device_id.Equals(info.device_id)).OrderBy(p => p.clm_date_time).ToList();
                                var Val077 = EDC077.Select(o => new CCS_Chart_Body(o.GetPropertyValue(edc_no).ToString(), ((DateTime)o.GetPropertyValue("clm_date_time")).ToString("yyyyMMddhhmmss"))).ToList();
                                Val077.ForEach(i => replydata.data_list.Add(i));
                                break;

                            case 78:
                                var EDC078 = db.IOT_DEVICE_EDC_078.AsQueryable().Where(o => o.device_id.Equals(info.device_id)).OrderBy(p => p.clm_date_time).ToList();
                                var Val078 = EDC078.Select(o => new CCS_Chart_Body(o.GetPropertyValue(edc_no).ToString(), ((DateTime)o.GetPropertyValue("clm_date_time")).ToString("yyyyMMddhhmmss"))).ToList();
                                Val078.ForEach(i => replydata.data_list.Add(i));
                                break;

                            case 79:
                                var EDC079 = db.IOT_DEVICE_EDC_079.AsQueryable().Where(o => o.device_id.Equals(info.device_id)).OrderBy(p => p.clm_date_time).ToList();
                                var Val079 = EDC079.Select(o => new CCS_Chart_Body(o.GetPropertyValue(edc_no).ToString(), ((DateTime)o.GetPropertyValue("clm_date_time")).ToString("yyyyMMddhhmmss"))).ToList();
                                Val079.ForEach(i => replydata.data_list.Add(i));
                                break;

                            case 80:
                                var EDC080 = db.IOT_DEVICE_EDC_080.AsQueryable().Where(o => o.device_id.Equals(info.device_id)).OrderBy(p => p.clm_date_time).ToList();
                                var Val080 = EDC080.Select(o => new CCS_Chart_Body(o.GetPropertyValue(edc_no).ToString(), ((DateTime)o.GetPropertyValue("clm_date_time")).ToString("yyyyMMddhhmmss"))).ToList();
                                Val080.ForEach(i => replydata.data_list.Add(i));
                                break;

                            case 81:
                                var EDC081 = db.IOT_DEVICE_EDC_081.AsQueryable().Where(o => o.device_id.Equals(info.device_id)).OrderBy(p => p.clm_date_time).ToList();
                                var Val081 = EDC081.Select(o => new CCS_Chart_Body(o.GetPropertyValue(edc_no).ToString(), ((DateTime)o.GetPropertyValue("clm_date_time")).ToString("yyyyMMddhhmmss"))).ToList();
                                Val081.ForEach(i => replydata.data_list.Add(i));
                                break;

                            case 82:
                                var EDC082 = db.IOT_DEVICE_EDC_082.AsQueryable().Where(o => o.device_id.Equals(info.device_id)).OrderBy(p => p.clm_date_time).ToList();
                                var Val082 = EDC082.Select(o => new CCS_Chart_Body(o.GetPropertyValue(edc_no).ToString(), ((DateTime)o.GetPropertyValue("clm_date_time")).ToString("yyyyMMddhhmmss"))).ToList();
                                Val082.ForEach(i => replydata.data_list.Add(i));
                                break;

                            case 83:
                                var EDC083 = db.IOT_DEVICE_EDC_083.AsQueryable().Where(o => o.device_id.Equals(info.device_id)).OrderBy(p => p.clm_date_time).ToList();
                                var Val083 = EDC083.Select(o => new CCS_Chart_Body(o.GetPropertyValue(edc_no).ToString(), ((DateTime)o.GetPropertyValue("clm_date_time")).ToString("yyyyMMddhhmmss"))).ToList();
                                Val083.ForEach(i => replydata.data_list.Add(i));
                                break;

                            case 84:
                                var EDC084 = db.IOT_DEVICE_EDC_084.AsQueryable().Where(o => o.device_id.Equals(info.device_id)).OrderBy(p => p.clm_date_time).ToList();
                                var Val084 = EDC084.Select(o => new CCS_Chart_Body(o.GetPropertyValue(edc_no).ToString(), ((DateTime)o.GetPropertyValue("clm_date_time")).ToString("yyyyMMddhhmmss"))).ToList();
                                Val084.ForEach(i => replydata.data_list.Add(i));
                                break;

                            case 85:
                                var EDC085 = db.IOT_DEVICE_EDC_085.AsQueryable().Where(o => o.device_id.Equals(info.device_id)).OrderBy(p => p.clm_date_time).ToList();
                                var Val085 = EDC085.Select(o => new CCS_Chart_Body(o.GetPropertyValue(edc_no).ToString(), ((DateTime)o.GetPropertyValue("clm_date_time")).ToString("yyyyMMddhhmmss"))).ToList();
                                Val085.ForEach(i => replydata.data_list.Add(i));
                                break;

                            case 86:
                                var EDC086 = db.IOT_DEVICE_EDC_086.AsQueryable().Where(o => o.device_id.Equals(info.device_id)).OrderBy(p => p.clm_date_time).ToList();
                                var Val086 = EDC086.Select(o => new CCS_Chart_Body(o.GetPropertyValue(edc_no).ToString(), ((DateTime)o.GetPropertyValue("clm_date_time")).ToString("yyyyMMddhhmmss"))).ToList();
                                Val086.ForEach(i => replydata.data_list.Add(i));
                                break;

                            case 87:
                                var EDC087 = db.IOT_DEVICE_EDC_087.AsQueryable().Where(o => o.device_id.Equals(info.device_id)).OrderBy(p => p.clm_date_time).ToList();
                                var Val087 = EDC087.Select(o => new CCS_Chart_Body(o.GetPropertyValue(edc_no).ToString(), ((DateTime)o.GetPropertyValue("clm_date_time")).ToString("yyyyMMddhhmmss"))).ToList();
                                Val087.ForEach(i => replydata.data_list.Add(i));
                                break;

                            case 88:
                                var EDC088 = db.IOT_DEVICE_EDC_088.AsQueryable().Where(o => o.device_id.Equals(info.device_id)).OrderBy(p => p.clm_date_time).ToList();
                                var Val088 = EDC088.Select(o => new CCS_Chart_Body(o.GetPropertyValue(edc_no).ToString(), ((DateTime)o.GetPropertyValue("clm_date_time")).ToString("yyyyMMddhhmmss"))).ToList();
                                Val088.ForEach(i => replydata.data_list.Add(i));
                                break;

                            case 89:
                                var EDC089 = db.IOT_DEVICE_EDC_089.AsQueryable().Where(o => o.device_id.Equals(info.device_id)).OrderBy(p => p.clm_date_time).ToList();
                                var Val089 = EDC089.Select(o => new CCS_Chart_Body(o.GetPropertyValue(edc_no).ToString(), ((DateTime)o.GetPropertyValue("clm_date_time")).ToString("yyyyMMddhhmmss"))).ToList();
                                Val089.ForEach(i => replydata.data_list.Add(i));
                                break;

                            case 90:
                                var EDC090 = db.IOT_DEVICE_EDC_090.AsQueryable().Where(o => o.device_id.Equals(info.device_id)).OrderBy(p => p.clm_date_time).ToList();
                                var Val090 = EDC090.Select(o => new CCS_Chart_Body(o.GetPropertyValue(edc_no).ToString(), ((DateTime)o.GetPropertyValue("clm_date_time")).ToString("yyyyMMddhhmmss"))).ToList();
                                Val090.ForEach(i => replydata.data_list.Add(i));
                                break;

                            case 91:
                                var EDC091 = db.IOT_DEVICE_EDC_091.AsQueryable().Where(o => o.device_id.Equals(info.device_id)).OrderBy(p => p.clm_date_time).ToList();
                                var Val091 = EDC091.Select(o => new CCS_Chart_Body(o.GetPropertyValue(edc_no).ToString(), ((DateTime)o.GetPropertyValue("clm_date_time")).ToString("yyyyMMddhhmmss"))).ToList();
                                Val091.ForEach(i => replydata.data_list.Add(i));
                                break;

                            case 92:
                                var EDC092 = db.IOT_DEVICE_EDC_092.AsQueryable().Where(o => o.device_id.Equals(info.device_id)).OrderBy(p => p.clm_date_time).ToList();
                                var Val092 = EDC092.Select(o => new CCS_Chart_Body(o.GetPropertyValue(edc_no).ToString(), ((DateTime)o.GetPropertyValue("clm_date_time")).ToString("yyyyMMddhhmmss"))).ToList();
                                Val092.ForEach(i => replydata.data_list.Add(i));
                                break;

                            case 93:
                                var EDC093 = db.IOT_DEVICE_EDC_093.AsQueryable().Where(o => o.device_id.Equals(info.device_id)).OrderBy(p => p.clm_date_time).ToList();
                                var Val093 = EDC093.Select(o => new CCS_Chart_Body(o.GetPropertyValue(edc_no).ToString(), ((DateTime)o.GetPropertyValue("clm_date_time")).ToString("yyyyMMddhhmmss"))).ToList();
                                Val093.ForEach(i => replydata.data_list.Add(i));
                                break;

                            case 94:
                                var EDC094 = db.IOT_DEVICE_EDC_094.AsQueryable().Where(o => o.device_id.Equals(info.device_id)).OrderBy(p => p.clm_date_time).ToList();
                                var Val094 = EDC094.Select(o => new CCS_Chart_Body(o.GetPropertyValue(edc_no).ToString(), ((DateTime)o.GetPropertyValue("clm_date_time")).ToString("yyyyMMddhhmmss"))).ToList();
                                Val094.ForEach(i => replydata.data_list.Add(i));
                                break;

                            case 95:
                                var EDC095 = db.IOT_DEVICE_EDC_095.AsQueryable().Where(o => o.device_id.Equals(info.device_id)).OrderBy(p => p.clm_date_time).ToList();
                                var Val095 = EDC095.Select(o => new CCS_Chart_Body(o.GetPropertyValue(edc_no).ToString(), ((DateTime)o.GetPropertyValue("clm_date_time")).ToString("yyyyMMddhhmmss"))).ToList();
                                Val095.ForEach(i => replydata.data_list.Add(i));
                                break;

                            case 96:
                                var EDC096 = db.IOT_DEVICE_EDC_096.AsQueryable().Where(o => o.device_id.Equals(info.device_id)).OrderBy(p => p.clm_date_time).ToList();
                                var Val096 = EDC096.Select(o => new CCS_Chart_Body(o.GetPropertyValue(edc_no).ToString(), ((DateTime)o.GetPropertyValue("clm_date_time")).ToString("yyyyMMddhhmmss"))).ToList();
                                Val096.ForEach(i => replydata.data_list.Add(i));
                                break;

                            case 97:
                                var EDC097 = db.IOT_DEVICE_EDC_097.AsQueryable().Where(o => o.device_id.Equals(info.device_id)).OrderBy(p => p.clm_date_time).ToList();
                                var Val097 = EDC097.Select(o => new CCS_Chart_Body(o.GetPropertyValue(edc_no).ToString(), ((DateTime)o.GetPropertyValue("clm_date_time")).ToString("yyyyMMddhhmmss"))).ToList();
                                Val097.ForEach(i => replydata.data_list.Add(i));
                                break;

                            case 98:
                                var EDC098 = db.IOT_DEVICE_EDC_098.AsQueryable().Where(o => o.device_id.Equals(info.device_id)).OrderBy(p => p.clm_date_time).ToList();
                                var Val098 = EDC098.Select(o => new CCS_Chart_Body(o.GetPropertyValue(edc_no).ToString(), ((DateTime)o.GetPropertyValue("clm_date_time")).ToString("yyyyMMddhhmmss"))).ToList();
                                Val098.ForEach(i => replydata.data_list.Add(i));
                                break;

                            case 99:
                                var EDC099 = db.IOT_DEVICE_EDC_099.AsQueryable().Where(o => o.device_id.Equals(info.device_id)).OrderBy(p => p.clm_date_time).ToList();
                                var Val099 = EDC099.Select(o => new CCS_Chart_Body(o.GetPropertyValue(edc_no).ToString(), ((DateTime)o.GetPropertyValue("clm_date_time")).ToString("yyyyMMddhhmmss"))).ToList();
                                Val099.ForEach(i => replydata.data_list.Add(i));
                                break;

                            case 100:
                                var EDC100 = db.IOT_DEVICE_EDC_100.AsQueryable().Where(o => o.device_id.Equals(info.device_id)).OrderBy(p => p.clm_date_time).ToList();
                                var Val100 = EDC100.Select(o => new CCS_Chart_Body(o.GetPropertyValue(edc_no).ToString(), ((DateTime)o.GetPropertyValue("clm_date_time")).ToString("yyyyMMddhhmmss"))).ToList();
                                Val100.ForEach(i => replydata.data_list.Add(i));
                                break;

                            case 101:
                                var EDC101 = db.IOT_DEVICE_EDC_101.AsQueryable().Where(o => o.device_id.Equals(info.device_id)).OrderBy(p => p.clm_date_time).ToList();
                                var Val101 = EDC101.Select(o => new CCS_Chart_Body(o.GetPropertyValue(edc_no).ToString(), ((DateTime)o.GetPropertyValue("clm_date_time")).ToString("yyyyMMddhhmmss"))).ToList();
                                Val101.ForEach(i => replydata.data_list.Add(i));
                                break;

                            case 102:
                                var EDC102 = db.IOT_DEVICE_EDC_102.AsQueryable().Where(o => o.device_id.Equals(info.device_id)).OrderBy(p => p.clm_date_time).ToList();
                                var Val102 = EDC102.Select(o => new CCS_Chart_Body(o.GetPropertyValue(edc_no).ToString(), ((DateTime)o.GetPropertyValue("clm_date_time")).ToString("yyyyMMddhhmmss"))).ToList();
                                Val102.ForEach(i => replydata.data_list.Add(i));
                                break;

                            case 103:
                                var EDC103 = db.IOT_DEVICE_EDC_103.AsQueryable().Where(o => o.device_id.Equals(info.device_id)).OrderBy(p => p.clm_date_time).ToList();
                                var Val103 = EDC103.Select(o => new CCS_Chart_Body(o.GetPropertyValue(edc_no).ToString(), ((DateTime)o.GetPropertyValue("clm_date_time")).ToString("yyyyMMddhhmmss"))).ToList();
                                Val103.ForEach(i => replydata.data_list.Add(i));
                                break;

                            case 104:
                                var EDC104 = db.IOT_DEVICE_EDC_104.AsQueryable().Where(o => o.device_id.Equals(info.device_id)).OrderBy(p => p.clm_date_time).ToList();
                                var Val104 = EDC104.Select(o => new CCS_Chart_Body(o.GetPropertyValue(edc_no).ToString(), ((DateTime)o.GetPropertyValue("clm_date_time")).ToString("yyyyMMddhhmmss"))).ToList();
                                Val104.ForEach(i => replydata.data_list.Add(i));
                                break;

                            case 105:
                                var EDC105 = db.IOT_DEVICE_EDC_105.AsQueryable().Where(o => o.device_id.Equals(info.device_id)).OrderBy(p => p.clm_date_time).ToList();
                                var Val105 = EDC105.Select(o => new CCS_Chart_Body(o.GetPropertyValue(edc_no).ToString(), ((DateTime)o.GetPropertyValue("clm_date_time")).ToString("yyyyMMddhhmmss"))).ToList();
                                Val105.ForEach(i => replydata.data_list.Add(i));
                                break;

                            case 106:
                                var EDC106 = db.IOT_DEVICE_EDC_106.AsQueryable().Where(o => o.device_id.Equals(info.device_id)).OrderBy(p => p.clm_date_time).ToList();
                                var Val106 = EDC106.Select(o => new CCS_Chart_Body(o.GetPropertyValue(edc_no).ToString(), ((DateTime)o.GetPropertyValue("clm_date_time")).ToString("yyyyMMddhhmmss"))).ToList();
                                Val106.ForEach(i => replydata.data_list.Add(i));
                                break;

                            case 107:
                                var EDC107 = db.IOT_DEVICE_EDC_107.AsQueryable().Where(o => o.device_id.Equals(info.device_id)).OrderBy(p => p.clm_date_time).ToList();
                                var Val107 = EDC107.Select(o => new CCS_Chart_Body(o.GetPropertyValue(edc_no).ToString(), ((DateTime)o.GetPropertyValue("clm_date_time")).ToString("yyyyMMddhhmmss"))).ToList();
                                Val107.ForEach(i => replydata.data_list.Add(i));
                                break;

                            case 108:
                                var EDC108 = db.IOT_DEVICE_EDC_108.AsQueryable().Where(o => o.device_id.Equals(info.device_id)).OrderBy(p => p.clm_date_time).ToList();
                                var Val108 = EDC108.Select(o => new CCS_Chart_Body(o.GetPropertyValue(edc_no).ToString(), ((DateTime)o.GetPropertyValue("clm_date_time")).ToString("yyyyMMddhhmmss"))).ToList();
                                Val108.ForEach(i => replydata.data_list.Add(i));
                                break;

                            case 109:
                                var EDC109 = db.IOT_DEVICE_EDC_109.AsQueryable().Where(o => o.device_id.Equals(info.device_id)).OrderBy(p => p.clm_date_time).ToList();
                                var Val109 = EDC109.Select(o => new CCS_Chart_Body(o.GetPropertyValue(edc_no).ToString(), ((DateTime)o.GetPropertyValue("clm_date_time")).ToString("yyyyMMddhhmmss"))).ToList();
                                Val109.ForEach(i => replydata.data_list.Add(i));
                                break;

                            case 110:
                                var EDC110 = db.IOT_DEVICE_EDC_110.AsQueryable().Where(o => o.device_id.Equals(info.device_id)).OrderBy(p => p.clm_date_time).ToList();
                                var Val110 = EDC110.Select(o => new CCS_Chart_Body(o.GetPropertyValue(edc_no).ToString(), ((DateTime)o.GetPropertyValue("clm_date_time")).ToString("yyyyMMddhhmmss"))).ToList();
                                Val110.ForEach(i => replydata.data_list.Add(i));
                                break;

                            case 111:
                                var EDC111 = db.IOT_DEVICE_EDC_111.AsQueryable().Where(o => o.device_id.Equals(info.device_id)).OrderBy(p => p.clm_date_time).ToList();
                                var Val111 = EDC111.Select(o => new CCS_Chart_Body(o.GetPropertyValue(edc_no).ToString(), ((DateTime)o.GetPropertyValue("clm_date_time")).ToString("yyyyMMddhhmmss"))).ToList();
                                Val111.ForEach(i => replydata.data_list.Add(i));
                                break;

                            case 112:
                                var EDC112 = db.IOT_DEVICE_EDC_112.AsQueryable().Where(o => o.device_id.Equals(info.device_id)).OrderBy(p => p.clm_date_time).ToList();
                                var Val112 = EDC112.Select(o => new CCS_Chart_Body(o.GetPropertyValue(edc_no).ToString(), ((DateTime)o.GetPropertyValue("clm_date_time")).ToString("yyyyMMddhhmmss"))).ToList();
                                Val112.ForEach(i => replydata.data_list.Add(i));
                                break;

                            case 113:
                                var EDC113 = db.IOT_DEVICE_EDC_113.AsQueryable().Where(o => o.device_id.Equals(info.device_id)).OrderBy(p => p.clm_date_time).ToList();
                                var Val113 = EDC113.Select(o => new CCS_Chart_Body(o.GetPropertyValue(edc_no).ToString(), ((DateTime)o.GetPropertyValue("clm_date_time")).ToString("yyyyMMddhhmmss"))).ToList();
                                Val113.ForEach(i => replydata.data_list.Add(i));
                                break;

                            case 114:
                                var EDC114 = db.IOT_DEVICE_EDC_114.AsQueryable().Where(o => o.device_id.Equals(info.device_id)).OrderBy(p => p.clm_date_time).ToList();
                                var Val114 = EDC114.Select(o => new CCS_Chart_Body(o.GetPropertyValue(edc_no).ToString(), ((DateTime)o.GetPropertyValue("clm_date_time")).ToString("yyyyMMddhhmmss"))).ToList();
                                Val114.ForEach(i => replydata.data_list.Add(i));
                                break;

                            case 115:
                                var EDC115 = db.IOT_DEVICE_EDC_115.AsQueryable().Where(o => o.device_id.Equals(info.device_id)).OrderBy(p => p.clm_date_time).ToList();
                                var Val115 = EDC115.Select(o => new CCS_Chart_Body(o.GetPropertyValue(edc_no).ToString(), ((DateTime)o.GetPropertyValue("clm_date_time")).ToString("yyyyMMddhhmmss"))).ToList();
                                Val115.ForEach(i => replydata.data_list.Add(i));
                                break;

                            case 116:
                                var EDC116 = db.IOT_DEVICE_EDC_116.AsQueryable().Where(o => o.device_id.Equals(info.device_id)).OrderBy(p => p.clm_date_time).ToList();
                                var Val116 = EDC116.Select(o => new CCS_Chart_Body(o.GetPropertyValue(edc_no).ToString(), ((DateTime)o.GetPropertyValue("clm_date_time")).ToString("yyyyMMddhhmmss"))).ToList();
                                Val116.ForEach(i => replydata.data_list.Add(i));
                                break;

                            case 117:
                                var EDC117 = db.IOT_DEVICE_EDC_117.AsQueryable().Where(o => o.device_id.Equals(info.device_id)).OrderBy(p => p.clm_date_time).ToList();
                                var Val117 = EDC117.Select(o => new CCS_Chart_Body(o.GetPropertyValue(edc_no).ToString(), ((DateTime)o.GetPropertyValue("clm_date_time")).ToString("yyyyMMddhhmmss"))).ToList();
                                Val117.ForEach(i => replydata.data_list.Add(i));
                                break;

                            case 118:
                                var EDC118 = db.IOT_DEVICE_EDC_118.AsQueryable().Where(o => o.device_id.Equals(info.device_id)).OrderBy(p => p.clm_date_time).ToList();
                                var Val118 = EDC118.Select(o => new CCS_Chart_Body(o.GetPropertyValue(edc_no).ToString(), ((DateTime)o.GetPropertyValue("clm_date_time")).ToString("yyyyMMddhhmmss"))).ToList();
                                Val118.ForEach(i => replydata.data_list.Add(i));
                                break;

                            case 119:
                                var EDC119 = db.IOT_DEVICE_EDC_119.AsQueryable().Where(o => o.device_id.Equals(info.device_id)).OrderBy(p => p.clm_date_time).ToList();
                                var Val119 = EDC119.Select(o => new CCS_Chart_Body(o.GetPropertyValue(edc_no).ToString(), ((DateTime)o.GetPropertyValue("clm_date_time")).ToString("yyyyMMddhhmmss"))).ToList();
                                Val119.ForEach(i => replydata.data_list.Add(i));
                                break;

                            case 120:
                                var EDC120 = db.IOT_DEVICE_EDC_120.AsQueryable().Where(o => o.device_id.Equals(info.device_id)).OrderBy(p => p.clm_date_time).ToList();
                                var Val120 = EDC120.Select(o => new CCS_Chart_Body(o.GetPropertyValue(edc_no).ToString(), ((DateTime)o.GetPropertyValue("clm_date_time")).ToString("yyyyMMddhhmmss"))).ToList();
                                Val120.ForEach(i => replydata.data_list.Add(i));
                                break;

                            case 121:
                                var EDC121 = db.IOT_DEVICE_EDC_121.AsQueryable().Where(o => o.device_id.Equals(info.device_id)).OrderBy(p => p.clm_date_time).ToList();
                                var Val121 = EDC121.Select(o => new CCS_Chart_Body(o.GetPropertyValue(edc_no).ToString(), ((DateTime)o.GetPropertyValue("clm_date_time")).ToString("yyyyMMddhhmmss"))).ToList();
                                Val121.ForEach(i => replydata.data_list.Add(i));
                                break;

                            case 122:
                                var EDC122 = db.IOT_DEVICE_EDC_122.AsQueryable().Where(o => o.device_id.Equals(info.device_id)).OrderBy(p => p.clm_date_time).ToList();
                                var Val122 = EDC122.Select(o => new CCS_Chart_Body(o.GetPropertyValue(edc_no).ToString(), ((DateTime)o.GetPropertyValue("clm_date_time")).ToString("yyyyMMddhhmmss"))).ToList();
                                Val122.ForEach(i => replydata.data_list.Add(i));
                                break;

                            case 123:
                                var EDC123 = db.IOT_DEVICE_EDC_123.AsQueryable().Where(o => o.device_id.Equals(info.device_id)).OrderBy(p => p.clm_date_time).ToList();
                                var Val123 = EDC123.Select(o => new CCS_Chart_Body(o.GetPropertyValue(edc_no).ToString(), ((DateTime)o.GetPropertyValue("clm_date_time")).ToString("yyyyMMddhhmmss"))).ToList();
                                Val123.ForEach(i => replydata.data_list.Add(i));
                                break;

                            case 124:
                                var EDC124 = db.IOT_DEVICE_EDC_124.AsQueryable().Where(o => o.device_id.Equals(info.device_id)).OrderBy(p => p.clm_date_time).ToList();
                                var Val124 = EDC124.Select(o => new CCS_Chart_Body(o.GetPropertyValue(edc_no).ToString(), ((DateTime)o.GetPropertyValue("clm_date_time")).ToString("yyyyMMddhhmmss"))).ToList();
                                Val124.ForEach(i => replydata.data_list.Add(i));
                                break;

                            case 125:
                                var EDC125 = db.IOT_DEVICE_EDC_125.AsQueryable().Where(o => o.device_id.Equals(info.device_id)).OrderBy(p => p.clm_date_time).ToList();
                                var Val125 = EDC125.Select(o => new CCS_Chart_Body(o.GetPropertyValue(edc_no).ToString(), ((DateTime)o.GetPropertyValue("clm_date_time")).ToString("yyyyMMddhhmmss"))).ToList();
                                Val125.ForEach(i => replydata.data_list.Add(i));
                                break;

                            case 126:
                                var EDC126 = db.IOT_DEVICE_EDC_126.AsQueryable().Where(o => o.device_id.Equals(info.device_id)).OrderBy(p => p.clm_date_time).ToList();
                                var Val126 = EDC126.Select(o => new CCS_Chart_Body(o.GetPropertyValue(edc_no).ToString(), ((DateTime)o.GetPropertyValue("clm_date_time")).ToString("yyyyMMddhhmmss"))).ToList();
                                Val126.ForEach(i => replydata.data_list.Add(i));
                                break;

                            case 127:
                                var EDC127 = db.IOT_DEVICE_EDC_127.AsQueryable().Where(o => o.device_id.Equals(info.device_id)).OrderBy(p => p.clm_date_time).ToList();
                                var Val127 = EDC127.Select(o => new CCS_Chart_Body(o.GetPropertyValue(edc_no).ToString(), ((DateTime)o.GetPropertyValue("clm_date_time")).ToString("yyyyMMddhhmmss"))).ToList();
                                Val127.ForEach(i => replydata.data_list.Add(i));
                                break;

                            case 128:
                                var EDC128 = db.IOT_DEVICE_EDC_128.AsQueryable().Where(o => o.device_id.Equals(info.device_id)).OrderBy(p => p.clm_date_time).ToList();
                                var Val128 = EDC128.Select(o => new CCS_Chart_Body(o.GetPropertyValue(edc_no).ToString(), ((DateTime)o.GetPropertyValue("clm_date_time")).ToString("yyyyMMddhhmmss"))).ToList();
                                Val128.ForEach(i => replydata.data_list.Add(i));
                                break;

                            default:

                                break;
                        }
                    }

                }
                return replydata;

            }
            catch (Exception ex)
            {
                _logger.Error(string.Format("Handle Service CCS_ChartInfo Query Device ID {0}, Chart Name {1},  Error Msg : {2}", info.device_id, info.chart_name, ex.Message));
                return new CCS_Chart_Info_Reply();
            }


        }

        public CCS_Online_Status Simu_AreYouThere()
        {
            CCS_Online_Status myStatus = new CCS_Online_Status();
            myStatus.status = "YES";
            return myStatus;
        }

        public CCS_Gateway_List Simu_GetGatewayList()
        {

            CCS_Gateway_List gatewayList = new CCS_Gateway_List();
            string simufile = Path.Combine(simudatapath, "gw_list.json");
            StreamReader inputFile1 = new StreamReader(simufile);
            string gw_list_json_string = inputFile1.ReadToEnd();
            gatewayList = JsonConvert.DeserializeObject<CCS_Gateway_List>(gw_list_json_string);
            inputFile1.Close();

            return gatewayList;
        }

        public CCS_Device_Detail Simu_GetDeviceDetail(string device_id)
        {

            CCS_Device_Detail_List device_detail_list = new CCS_Device_Detail_List();

            string simufile = Path.Combine(simudatapath, "dvd_list.json");
            StreamReader inputFile2 = new StreamReader(simufile);
            string dvd_list_json_string = inputFile2.ReadToEnd();
            device_detail_list = JsonConvert.DeserializeObject<CCS_Device_Detail_List>(dvd_list_json_string);
            inputFile2.Close();

            return device_detail_list.dvd_list.FirstOrDefault(n => n.device_id == device_id);
        }

        public CCS_Device_Item Simu_GetChartItemList(string device_id)
        {

            CCS_ChartItem_List chart_item_list = new CCS_ChartItem_List();

            string simufile = Path.Combine(simudatapath, "item_list.json");
            StreamReader inputFile3 = new StreamReader(simufile);
            string item_list_json_string = inputFile3.ReadToEnd();
            chart_item_list = JsonConvert.DeserializeObject<CCS_ChartItem_List>(item_list_json_string);
            inputFile3.Close();

            return chart_item_list.device_item_list.FirstOrDefault(p => p.device_id == device_id);
        }

        public CCS_Alarm_List Simu_GetAlarmList()
        {
            CCS_Alarm_List alarm_list = new CCS_Alarm_List();

            string simufile = Path.Combine(simudatapath, "alarm_list.json");
            StreamReader inputFile4 = new StreamReader(simufile);
            string alarm_list_json_string = inputFile4.ReadToEnd();
            alarm_list = JsonConvert.DeserializeObject<CCS_Alarm_List>(alarm_list_json_string);
            inputFile4.Close();

            return alarm_list;
        }

        public BLEProfileList Simu_GetBLEProfileList()
        {
            BLEProfileList profile_list = new BLEProfileList();

            string simufile = Path.Combine(simudatapath, "ble_profile_list.json");
            StreamReader inputFile5 = new StreamReader(simufile);
            string profile_list_json_string = inputFile5.ReadToEnd();
            profile_list = JsonConvert.DeserializeObject<BLEProfileList>(profile_list_json_string);
            inputFile5.Close();

            return profile_list;
        }

        public CCS_Chart_Info_Reply Simu_PostDeviceDetail(CCS_Chart_Info_Req info)
        {

            CCS_Chart_Info_Reply replydata = new CCS_Chart_Info_Reply();
            replydata.device_id = info.device_id;

            int data_count;

            DateTime start_datetime;
            DateTime end_datetime;
            string formatString = "yyyyMMddHHmmss";

            try
            {
                data_count = int.Parse(info.get_count);
                start_datetime = DateTime.ParseExact(info.start_time, formatString, null);
                end_datetime = DateTime.ParseExact(info.end_time, formatString, null);
            }
            catch (Exception ex)
            {
                return replydata;
            }

            TimeSpan ts = end_datetime.Subtract(start_datetime).Duration();
            int secondsbyrecord =Convert.ToInt32( ts.TotalSeconds / (double)data_count);

            for (int i=0; i< data_count; i++)
            {
                int add_seconds = secondsbyrecord * i;
                DateTime tmp = start_datetime.AddSeconds(add_seconds);
                string tmp_x = tmp.ToString("yyyyMMddHHmmss");
                string tmp_y = GetRandomNumber(10.0, 100.0).ToString();
                CCS_Chart_Body tmp_chart = new CCS_Chart_Body(tmp_y, tmp_x);
                replydata.data_list.Add(tmp_chart);

            }
            return replydata;
        }

        public double GetRandomNumber(double minimum, double maximum)
        {
            return getrandom.NextDouble() * (maximum - minimum) + minimum;
        }
    }
}
