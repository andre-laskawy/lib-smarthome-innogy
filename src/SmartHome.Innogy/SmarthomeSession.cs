///-----------------------------------------------------------------
///   File:         SmarthomeSession.cs
///   Author:   	Andre Laskawy           
///   Date:         11.10.2018 20:11:28
///-----------------------------------------------------------------

namespace SmartHome.Innogy
{
    using SmartHome.Innogy.Enums;
    using SmartHome.Innogy.Handler;
    using SmartHome.Innogy.Models;
    using SmartHome.Innogy.Models.Base;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;

    /// <summary>
    /// Defines the <see cref="SmarthomeSession" />
    /// </summary>
    public class SmarthomeSession
    {
        /// <summary>
        /// Gets or sets the websocker handler.
        /// </summary>
        private InnogyWebSocketHandler websockerHandler { get; set; }

        /// <summary>
        /// Gets or sets the authentication handler.
        /// </summary>
        private AuthentificationHandler authHandler { get; set; }

        /// <summary>
        /// Gets or sets the innogy event.
        /// </summary>
        public Action<EventData> InnogyEvent { get; set; }

        /// <summary>
        /// Gets or sets the current conf.
        /// </summary>
        public CurrentConf CurrentConf { get; set; }

        /// <summary>
        /// Gets or sets the User
        /// </summary>
        public User User { get; set; }

        /// <summary>
        /// Gets or sets the Locations
        /// </summary>
        public List<Location> Locations { get; set; }

        /// <summary>
        /// Gets or sets the location types.
        /// </summary>
        public List<LocationTypes> LocationTypes { get; set; }

        /// <summary>
        /// Gets or sets the Devices
        /// </summary>
        public List<Device> Devices { get; set; }

        /// <summary>
        /// Gets or sets the device states.
        /// </summary>
        public List<DeviceState> DeviceStates { get; set; }

        /// <summary>
        /// Gets or sets the Capabilities
        /// </summary>
        public List<Capability> Capabilities { get; set; }

        /// <summary>
        /// Gets or sets the capability states.
        /// </summary>
        public List<DeviceState> CapabilityStates { get; set; }

        /// <summary>
        /// Gets or sets the Interactions
        /// </summary>
        public List<Interaction> Interactions { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is initialized.
        /// </summary>
        public bool IsInitialized { get; set; }

        /// <summary>
        /// Gets or sets the Messages
        /// </summary>
        public List<Message> Messages { get; set; }

        /// <summary>
        /// Refreshes the token.
        /// </summary>
        public void RefreshToken()
        {
            if (string.IsNullOrEmpty(authHandler.RefreshToken))
            {
                return;
            }

            authHandler.Login(authHandler.RefreshToken);
        }

        /// <summary>
        /// Logins the specified user name.
        /// </summary>
        /// <param name="userName">Name of the user.</param>
        /// <param name="password">The password.</param>
        /// <returns></returns>
        public bool Login(string userName, string password)
        {
            authHandler = new AuthentificationHandler();
            this.websockerHandler = new InnogyWebSocketHandler();
            this.websockerHandler.InnogyEvent = websh_InnogyEvent;

            this.IsInitialized = false;
            authHandler.Login(userName, password);

            if (!authHandler.CredentialsCorrect)
                return false;

            return true;
        }

        /// <summary>
        /// Initializes the data.
        /// </summary>
        public void InitializeData()
        {
            InnogyRequestHandler reqH = default(InnogyRequestHandler);
            reqH = new InnogyRequestHandler(authHandler.Token);

            if (!this.IsInitialized)
            {
                CurrentConf = reqH.Perform(RequestTyp.Initialize) as CurrentConf;

                //User
                User = reqH.Perform(RequestTyp.User) as User;

                //Nachrichten
                Messages = reqH.Perform(RequestTyp.Message) as List<Message>;

                //Ortes
                Locations = reqH.Perform(RequestTyp.Location) as List<Location>;
                LocationTypes = reqH.Perform(RequestTyp.LocationTypes) as List<LocationTypes>;

                //Geräte-Daten
                Devices = reqH.Perform(RequestTyp.Device) as List<Device>;
                DeviceStates = reqH.Perform(RequestTyp.DeviceState) as List<DeviceState>;

                //Funktionen
                Capabilities = reqH.Perform(RequestTyp.Capability) as List<Capability>;
                CapabilityStates = reqH.Perform(RequestTyp.CapabilityState) as List<DeviceState>;

                //Szenarien
                Interactions = reqH.Perform(RequestTyp.Interaction) as List<Interaction>;

                this.IsInitialized = true;
                this.websockerHandler.Open(authHandler.Token);
            }
        }

        /// <summary>
        /// Does the action.
        /// </summary>
        /// <param name="actInf">The act inf.</param>
        /// <returns></returns>
        public bool DoAction(ActionInfo actInf)
        {
            ActionResponse actres = default(ActionResponse);
            InnogyRequestHandler reqH = new InnogyRequestHandler(authHandler.Token);

            actres = reqH.Perform(RequestTyp.Action, actInf.ToInAction()) as ActionResponse;
            if (actres.ResultCode == "Success")
            {
                IHasID iObejct = GetObjectByID<DeviceState>(actInf.ID);
                if (iObejct.GetType() == typeof(DeviceState))
                {
                    (iObejct as DeviceState).State.Find(s => s.Name == actInf.Setting).Value = actInf.Value.ToString();
                }
                return true;
            }
            return false;
        }

        /// <summary>
        /// Gets the activities.
        /// </summary>
        /// <param name="devActInf">The dev act inf.</param>
        /// <returns></returns>
        public DeviceActivity GetActivities(DeviceActivityInfo devActInf)
        {
            InnogyRequestHandler reqH = new InnogyRequestHandler(authHandler.Token);
            DeviceActivity devData = new DeviceActivity();
            DeviceActivity dynDevData = default(DeviceActivity);
            int p = 0;

            //Mehrere Requests ausführen, da nur 100 Datensätze pro Request geliefert werden
            p = 0;
            do
            {
                p += 1;
                dynDevData = reqH.Perform(RequestTyp.DeviceActivity, devActInf.ToQuery(p)) as DeviceActivity;
                if (p == 1)
                {
                    devData = dynDevData;
                }
                else
                {
                    devData.Activities.AddRange(dynDevData.Activities);
                }

                Thread.Sleep(600);
            } while (devData.Count > p * 100);

            devData.Returned = devData.Activities.Count;
            return devData;
        }

        /// <summary>
        /// Gets the object by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public IHasID GetObjectByID(string id)
        {
            return GetObjectByID<IHasID>(id);
        }

        /// <summary>
        /// Gets the object by identifier.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public IHasID GetObjectByID<T>(string id) where T : IHasID
        {
            List<IEnumerable<IHasID>> lList = new List<IEnumerable<IHasID>>();
            IEnumerable<IHasID> dynList = default(IEnumerable<IHasID>);

            switch (typeof(T).ToString())
            {
                case "DeviceState":
                    lList.Add(this.CapabilityStates);
                    lList.Add(this.DeviceStates);
                    break;

                case "Device":
                    lList.Add(this.Devices);
                    break;

                case "Capability":
                    lList.Add(this.Capabilities);
                    break;

                case "Location":
                    lList.Add(this.Locations);
                    break;

                case "Interaction":
                    lList.Add(this.Interactions);
                    break;

                default:
                    lList.Add(this.Capabilities);
                    lList.Add(this.Devices);
                    lList.Add(this.Locations);
                    lList.Add(this.Interactions);
                    lList.Add(this.CapabilityStates);
                    lList.Add(this.DeviceStates);
                    break;
            }

            if ((lList != null))
            {
                foreach (var l_loopVariable in lList)
                {
                    if ((l_loopVariable != null))
                    {
                        dynList = l_loopVariable.Where(o => o.ID == id);
                        if (dynList.Count() > 0)
                            return dynList.First();
                    }
                }
            }

            return default(T);
        }

        /// <summary>
        /// Refreshes the states.
        /// </summary>
        public void RefreshStates()
        {
            InnogyRequestHandler reqH = new InnogyRequestHandler(authHandler.Token);
            DeviceStates = reqH.Perform(RequestTyp.DeviceState) as List<DeviceState>;
            CapabilityStates = reqH.Perform(RequestTyp.CapabilityState) as List<DeviceState>;
        }

        /// <summary>
        /// Webshes the innogy event.
        /// </summary>
        /// <param name="data">The data.</param>
        private void websh_InnogyEvent(EventData data)
        {
            //Ggf. State anpassen
            if (data.Type.Split('/').Last() == "StateChanged")
            {
                IHasID Iobject = GetObjectByID<DeviceState>(data.Link.CleanValue.ToString().Replace("/", ""));
            }

            InnogyEvent?.Invoke(data);
        }
    }
}