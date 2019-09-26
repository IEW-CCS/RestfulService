using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace Restful
{
    // 注意: 您可以使用 [重構] 功能表上的 [重新命名] 命令同時變更程式碼和組態檔中的介面名稱 "IService1"。
    [ServiceContract]
    public interface IRestfulService
    {

        [OperationContract]
        string GetData(int value);

        [OperationContract]
        CompositeType GetDataUsingDataContract(CompositeType composite);


        [OperationContract]
        [WebGet(UriTemplate = "CCS_Gateway_List", BodyStyle = WebMessageBodyStyle.Bare, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        CCS_Gateway_List GetGatewayList();

        [OperationContract]
        [WebGet(UriTemplate = "CCS_Device_Detail/{device_id}", BodyStyle = WebMessageBodyStyle.Bare, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        CCS_Device_Detail GetDeviceDetail(string device_id);

        [OperationContract]
        [WebGet(UriTemplate = "CCS_Chart_Item_List/{device_id}", BodyStyle = WebMessageBodyStyle.Bare, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        CCS_Device_Item GetChartItemList(string device_id);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "CCS_Chart/Info", BodyStyle = WebMessageBodyStyle.Bare, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        CCS_Chart_Info_Reply PostDeviceDetail(CCS_Chart_Info_Req info);



        //------- for simulation ------
        [OperationContract]
        [WebGet(UriTemplate = "simulation/CCS_Gateway_List", BodyStyle = WebMessageBodyStyle.Bare, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        CCS_Gateway_List Simu_GetGatewayList();

        [OperationContract]
        [WebGet(UriTemplate = "simulation/CCS_Device_Detail/{device_id}", BodyStyle = WebMessageBodyStyle.Bare, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        CCS_Device_Detail Simu_GetDeviceDetail(string device_id);

        [OperationContract]
        [WebGet(UriTemplate = "simulation/CCS_Chart_Item_List/{device_id}", BodyStyle = WebMessageBodyStyle.Bare, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        CCS_Device_Item Simu_GetChartItemList(string device_id);

        [OperationContract]
        [WebGet(UriTemplate = "simulation/CCS_Alarm_List", BodyStyle = WebMessageBodyStyle.Bare, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        CCS_Alarm_List Simu_GetAlarmList();

        [OperationContract]
        [WebGet(UriTemplate = "simulation/CCS_BLE_Profile_List", BodyStyle = WebMessageBodyStyle.Bare, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        BLEProfileList Simu_GetBLEProfileList();


    }


    
}
