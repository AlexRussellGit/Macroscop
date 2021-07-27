namespace WPF_BIOSTAR2_APPLICATION.RequestResponse.SearchEvent
{
    using APIClassLibrary;
    using WPF_BIOSTAR2_APPLICATION.Data.DataStructure.List;
    using WPF_BIOSTAR2_APPLICATION.RequestResponse.SearchEvent.ResponseModel;
    using Newtonsoft.Json;
    using System;
    using System.Windows;
    public class Search
    {
        public static void SearchEventListResponse(Nullable<DateTime> firstdate, Nullable<DateTime> lastdate) // Получает Запрос в String и конвертирует в Obj (типа)
        {
            DeserializeClassObject MyObj = JsonConvert.DeserializeObject<DeserializeClassObject>(SystemInteraction.GetSearchEventResponseString(firstdate, lastdate));
            SearchEventList.ClearInstance();
            if (MyObj.EventCollection.rows == null)
            {
                MessageBox.Show("List is Empty!");
            }
            else
            {
                foreach (Row obj_row_field in MyObj.EventCollection.rows)
                {
                    SearchEventList.AddInstance(Convert.ToString(obj_row_field.datetime), DoorID_NameString(obj_row_field) , obj_row_field.device_id.id, obj_row_field.device_id.name, obj_row_field.user_group_id.name, obj_row_field.user_id.name, obj_row_field.event_type_id.code);
                }
            }
        }

        public static string DoorID_NameString(Row MyArr)
        {
            if (MyArr.door_id == null)
            {
                return null;
            }
            return MyArr.door_id[MyArr.door_id.Length-1].name;
        }
    }
}
