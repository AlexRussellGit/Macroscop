namespace WPF_BIOSTAR2_APPLICATION.Data.DataStructure.List
{
    using WPF_BIOSTAR2_APPLICATION.Data.DataBase.Class;
    using System.Collections.ObjectModel;
    using System.Windows;
    class SearchEventList : DependencyObject    // The List Which is beeing used to be showed on the main window
    {                                           // At the top we make a Static List which we use in the program
                                                // Lower are located methods to use this class in other places od the program

        private static ObservableCollection<SearchEventClass> MyCollectionInstance = new ObservableCollection<SearchEventClass>
        {
            new SearchEventClass() { Date ="25.01.2021", Door = "265", DeviceId = "546", Device = "devCharl2", UserGroup ="user", User = "Charl", Event ="DoorOpen" },
            new SearchEventClass() { Date ="25.01.2021", Door = "234", DeviceId = "847", Device = "devPang01", UserGroup ="admin", User = "Pang", Event ="DoorLock" },
            new SearchEventClass() { Date ="25.01.2021", Door = "234", DeviceId = "847", Device = "devPang01", UserGroup ="admin", User = "Pang", Event ="DoorOpen" },
            new SearchEventClass() { Date ="25.01.2021", Door = "234", DeviceId = "847", Device = "devPang01", UserGroup ="admin", User = "Pang", Event ="DoorLock" },
            new SearchEventClass() { Date ="25.01.2021", Door = "265", DeviceId = "546", Device = "devCharl2", UserGroup ="user", User = "Charl", Event ="DoorLock" },
            new SearchEventClass() { Date ="25.01.2021", Door = "234", DeviceId = "546", Device = "devCharl2", UserGroup ="user", User = "Charl", Event ="DoorOpen" },
            new SearchEventClass() { Date ="25.01.2021", Door = "234", DeviceId = "847", Device = "devPang01", UserGroup ="admin", User = "Pang", Event ="DoorOpen" },
            new SearchEventClass() { Date ="26.01.2021", Door = "265", DeviceId = "546", Device = "devCharl2", UserGroup ="user", User = "Charl", Event ="DoorOpen" },
            new SearchEventClass() { Date ="26.01.2021", Door = "234", DeviceId = "546", Device = "devCharl2", UserGroup ="user", User = "Charl", Event ="DoorLock" },
            new SearchEventClass() { Date ="26.01.2021", Door = "265", DeviceId = "847", Device = "devPang01", UserGroup ="admin", User = "Pang", Event ="DoorLock" },
            new SearchEventClass() { Date ="26.01.2021", Door = "234", DeviceId = "546", Device = "devCharl2", UserGroup ="user", User = "Charl", Event ="DoorOpen" },
            new SearchEventClass() { Date ="26.01.2021", Door = "265", DeviceId = "546", Device = "devCharl2", UserGroup ="user", User = "Charl", Event ="DoorOpen" },
            new SearchEventClass() { Date ="26.01.2021", Door = "265", DeviceId = "847", Device = "devPang01", UserGroup ="admin", User = "Pang", Event ="DoorLock" }
        };
        public static void AddInstance(string _datetime, string _door, string _deviceid, string _devicename, string _usergroup, string _user, string _event)
        {
            MyCollectionInstance.Add(new SearchEventClass() { Date = _datetime, Door = _door, DeviceId = _deviceid, Device = _devicename, UserGroup = _usergroup, User = _user, Event = _event });
        }
        public static void ClearInstance()
        {
            MyCollectionInstance.Clear();
        }
        public static ObservableCollection<SearchEventClass> GetElement()
        {
            return MyCollectionInstance;
        }
        //
        private ObservableCollection<SearchEventClass> MyCollection = new ObservableCollection<SearchEventClass>();
        public void Add(string str1, string str2, string str3, string str4, string str5, string str6, string str7)
        {
            MyCollection.Add(new SearchEventClass() { Date = str1, Door = str2, DeviceId = str3, Device = str4, UserGroup = str5, User = str6, Event = str7 });
        }
        public void Clear()
        {
            MyCollection.Clear();
        }
        public ObservableCollection<SearchEventClass> Get()
        {
            return MyCollection;
        }
    }
    
}
