using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainLayer.Bookings;

namespace DataLayer.DataMappers
{
    public interface IInvoiceMapper
    {
        Invoice Create(Invoice invoice);
    }
}
