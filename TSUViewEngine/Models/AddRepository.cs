using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TSUViewEngine.Models
{
    public interface IAddRepository
    {
        IEnumerable<AddModel> Adds { get; }
    }

    public class AddRepository : IAddRepository
    {
        private List<AddModel> Data = new List<AddModel>()
        {
            new AddModel(){Id= 1, Url="https://open5.myvideo.ge/delivery/afrs2.php?zid=303&cb=0.7803166440457889" }
        };
        public IEnumerable<AddModel> Adds
        {
            get { return Data; }
        }
    }
}
