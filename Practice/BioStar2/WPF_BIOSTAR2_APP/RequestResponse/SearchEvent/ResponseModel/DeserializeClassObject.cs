namespace WPF_BIOSTAR2_APPLICATION.RequestResponse.SearchEvent.ResponseModel
{
    using System;
    public class DeserializeClassObject
    {
        public Eventcollection EventCollection { get; set; }
        public Response Response { get; set; }
    }

    public class Eventcollection
    {
        public Row[] rows { get; set; }
    }

    public class Row
    {
        public string id { get; set; }
        public DateTime server_datetime { get; set; }
        public DateTime datetime { get; set; }
        public string index { get; set; }
        public string user_id_name { get; set; }
        public User_Id user_id { get; set; }
        public User_Group_Id user_group_id { get; set; }
        public Device_Id device_id { get; set; }
        public Event_Type_Id event_type_id { get; set; }
        public string is_dst { get; set; }
        public Timezone timezone { get; set; }
        public string user_update_by_device { get; set; }
        public string hint { get; set; }
        public Door_Id[] door_id { get; set; }
    }

    public class User_Id
    {
        public string user_id { get; set; }
        public string name { get; set; }
        public string photo_exists { get; set; }
    }

    public class User_Group_Id
    {
        public string id { get; set; }
        public string name { get; set; }
    }

    public class Device_Id
    {
        public string id { get; set; }
        public string name { get; set; }
    }

    public class Event_Type_Id
    {
        public string code { get; set; }
    }

    public class Timezone
    {
        public string half { get; set; }
        public string hour { get; set; }
        public string negative { get; set; }
    }

    public class Door_Id
    {
        public string id { get; set; }
        public string name { get; set; }
    }

    public class Response
    {
        public string code { get; set; }
        public string link { get; set; }
        public string message { get; set; }
    }
}
