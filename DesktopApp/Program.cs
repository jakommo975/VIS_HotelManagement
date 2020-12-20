using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using SimpleInjector;
using SimpleInjector.Diagnostics;
using ServiceLayer;
using ServiceLayer.Bookings;
using DomainLayer.Users;
using DomainLayer.Bookings;
using DomainLayer.Rooms;
using DataLayer.DataMappers;
using DataLayer;


namespace DesktopApp
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var container = Bootstrap();

            Application.Run(container.GetInstance<TopLevelView>());
        }

        public static System.ComponentModel.BindingList<T> ToBindingList<T>(this IEnumerable<T> data)
        {
            System.ComponentModel.BindingList<T> result = null;
            if (data != null)
            {
                result = new System.ComponentModel.BindingList<T>();
                foreach (T item in data)
                {
                    result.Add(item);
                }
            }
            return result;
        }

        private static Container Bootstrap()
        {
            // Create the container as usual.
            var container = new Container();

            // Register your types, for instance:

            container.Register<IDatabase, Database>();
            container.Register<IRoomMapper, RoomMapper>();
            container.Register<IUserMapper, UserMapper>();
            container.Register<IRoomTypeMapper, RoomTypeMapper>();
            container.Register<IRoomBookingMapper, RoomBookingMapper>();
            container.Register<IInvoiceMapper, InvoiceMapper>();
            container.Register<IRoomKeyMapper, RoomKeyMapper>();
            container.Register<IUserXmlMapper, UserXmlMapper>();

            container.Register<IBookingService, BookingService>();
            container.Register<IRoomService, RoomService>();

            container.Register<IUserService, UserService>();



            AutoRegisterWindowsForms(container);

            container.Verify();

            return container;
        }

        private static void AutoRegisterWindowsForms(Container container)
        {
            var types = container.GetTypesToRegister<Form>(typeof(Program).Assembly);

            foreach (var type in types)
            {
                var registration =
                    Lifestyle.Transient.CreateRegistration(type, container);

                registration.SuppressDiagnosticWarning(
                    DiagnosticType.DisposableTransientComponent,
                    "Forms should be disposed by app code; not by the container.");

                container.AddRegistration(type, registration);
            }
        }
    }
}
