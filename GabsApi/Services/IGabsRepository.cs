using System.Collections.Generic;
using GabsApi.Model;

namespace GabsApi.Repository
{
    public interface IGabsRepository
    {
        IEnumerable<Gabs> GetGabss();

        Gabs GetGabs(int id);

        public IEnumerable<OtherGabs> GetOtherGabss();

        public OtherGabs GetOtherGabs(int gabsId, int id);

        public void AddNewGabs(int id, OtherGabs otherGabs);

        public bool GabsExists(int id);

        public bool Save();
    }
}