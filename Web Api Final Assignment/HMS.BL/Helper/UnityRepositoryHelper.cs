using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;
using Unity.Extension;
using HMS.DL.Repository;

namespace HMS.BL.Helper
{
    public class UnityRepositoryHelper : UnityContainerExtension
    {
        protected override void Initialize()
        {
            Container.RegisterType<IHotelRepository, HotelRepository>();
        }
    }
}
