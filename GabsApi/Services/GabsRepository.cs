using System.Collections.Generic;
using System.Linq;
using GabsApi.Context;
using GabsApi.Model;

namespace GabsApi.Repository
{
    public class GabsRepository : IGabsRepository
    {
        private readonly GabsContext _context;

        public GabsRepository(GabsContext context)
        {
            _context = context;
        }

        public IEnumerable<Gabs> GetGabss()
        {
            return _context.Gabss.OrderBy(_ => _.Name).ToList();
        }

        public Gabs GetGabs(int id)
        {
            return _context.Gabss.Where(_ => _.Id == id).FirstOrDefault();
        }

        public IEnumerable<OtherGabs> GetOtherGabss()
        {
            return _context.OtherGabss.OrderBy(_ => _.Name).ToList();
        }

        public OtherGabs GetOtherGabs(int gabsId, int id)
        {
            return _context.OtherGabss.Where(_ => _.GabsId == gabsId && _.Id == id).FirstOrDefault();
        }

        public void AddNewGabs(int id, OtherGabs otherGabs)
        {
            var getGabs = GetGabs(id);
            getGabs.GabsList.Add(otherGabs);
        }

        public bool GabsExists(int id)
        {
            return _context.Gabss.Any(_ => _.Id == id);
        }

        public bool Save()
        {
            return _context.SaveChanges() >= 0;
        }
    }
}