using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace GE_DB
{
    public class GEDatabase
    {
        protected GE_DBContext GE;
        public static GEDatabase Init(string Connection_String)
        {
            //"Server=(localdb)\\mssqllocaldb;Database=GE_BD;Trusted_Connection=True;"
            return new GEDatabase(Connection_String);
        }


        private GEDatabase(string Connection_String)
        {
            GE = new GE_DBContext(Connection_String);
        }


        public EnergySource EnergySourceFind(int Id)
        {
            return GE.EnergySources.FirstOrDefault(ES => ES.Id == Id);
        }
        public Accumulator AccumulatorFind(int Id)
        {
            return GE.Accumulators.FirstOrDefault(A => A.Id == Id);
        }
        public Inverter InverterFind(int Id)
        {
            return GE.Inverters.FirstOrDefault(I => I.Id == Id);
        }
        public Region RegionFind(int Id)
        {
            return GE.Regions.FirstOrDefault(R => R.Id == Id);
        }
        public Region RegionFind(int Province_ID, int InProvince_ID)
        {
            return GE.Regions.FirstOrDefault(R => R.Province_ID == Province_ID && R.InProvince_ID == InProvince_ID);
        }


        public void EnergySourceInsert(EnergySource ES)
        {
            GE.EnergySources.Add(ES);
            GE.SaveChanges();
        }
        public void AccumulatorInsert(Accumulator A)
        {
            GE.Accumulators.Add(A);
            GE.SaveChanges();
        }
        public void RegionInsert(Region R)
        {
            GE.Regions.Add(R);
            GE.SaveChanges();
        }
        public void InverterInsert(Inverter I)
        {
            GE.Inverters.Add(I);
            GE.SaveChanges();
        }


        public void EnergySourceRemove(int Id)
        {
            GE.Remove(GE.EnergySources.FirstOrDefault(ES => ES.Id == Id));
            GE.SaveChanges();
        }
        public void AccumulatorRemove(int Id)
        {
            GE.Remove(GE.Accumulators.FirstOrDefault(A => A.Id == Id));
            GE.SaveChanges();
        }
        public void InverterRemove(int Id)
        {
            GE.Remove(GE.Inverters.FirstOrDefault(I => I.Id == Id));
            GE.SaveChanges();
        }
        public void RegionRemove(int Id)
        {
            GE.Regions.RemoveRange(GE.Regions.FirstOrDefault(I => I.Id == Id));
            GE.SaveChanges();
        }
        public void RegionRemove(int Province_ID, int InProvince_ID)
        {
            GE.Remove(GE.Regions.FirstOrDefault(R => R.Province_ID == Province_ID && R.InProvince_ID == InProvince_ID));
            GE.SaveChanges();
        }

        public List<int> EnergySourceIds()
        {
            var ESs = GE.EnergySources.Select(ES => new { ES.Id }).ToList();
            List<int> IDs = new List<int>();
            foreach (var v in ESs)
            {
                IDs.Add(v.Id);
            }
            return IDs;
        }
        public List<int> AccumlatorIds()
        {
            var As = GE.Accumulators.Select(A => new { A.Id }).ToList();
            List<int> IDs = new List<int>();
            foreach (var v in As)
            {
                IDs.Add(v.Id);
            }
            return IDs;
        }
        public List<int> InverterIds()
        {
            var Is = GE.Inverters.Select(I => new { I.Id }).ToList();
            List<int> IDs = new List<int>();
            foreach (var v in Is)
            {
                IDs.Add(v.Id);
            }
            return IDs;
        }
        public List<int> RegionIds()
        {
            var Rs = GE.Regions.Select(R => new { R.Id }).ToList();
            List<int> IDs = new List<int>();
            foreach (var v in Rs)
            {
                IDs.Add(v.Id);
            }
            return IDs;
        }
        public List<int> RegionProvinceIds()
        {
            var Rs = GE.Regions.Select(R => new { R.Province_ID }).ToList();
            List<int> IDs = new List<int>();
            foreach (var v in Rs)
            {
                IDs.Add(v.Province_ID);
            }
            return IDs;
        }
        public List<int> RegionInProvinceIds(int Province_ID)
        {
            var Rs = GE.Regions.Where(R => R.Province_ID == Province_ID).Select(R => new { R.InProvince_ID }).ToList();
            List<int> IDs = new List<int>();
            foreach (var v in Rs)
            {
                IDs.Add(v.InProvince_ID);
            }
            return IDs;
        }



    }
}
