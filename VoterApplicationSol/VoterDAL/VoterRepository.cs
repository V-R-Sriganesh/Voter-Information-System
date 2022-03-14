using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VoterDAL
{
   
    public class VoterRepository
    {
        private VoterAppEntities cxt;

        public VoterRepository()
        {
            cxt = new VoterAppEntities();
        }

        public adminuser validateAdmin(string em,string p)
        {
            adminuser user = null;

            try
            {
                user = cxt.adminusers.Where(v => v.email == em && v.passwrd == p).FirstOrDefault();
            }
            catch
            {
                user = null;
            }
            return user;
        }

        public bool addVoter(voter vobj)
        {
            if(vobj == null)
            {
                return false;
            }
            try
            {
                cxt.voters.Add(vobj);
                cxt.SaveChanges();
            }
            catch
            {
                return false;
            }
            return true;
        }

        public voter searchVoter(int vid)
        {
            voter vobj = null;

            try
            {
                vobj = cxt.voters.Find(vid);
            }
            catch
            {
                vobj=null;
            }
            return vobj;
        }

        public bool updateVoter(voter vobj)
        {
            if(vobj == null)
                return false;
            try
            {
                cxt.Entry(vobj).State = System.Data.Entity.EntityState.Modified;
                cxt.SaveChanges();
            }
            catch
            {
                return false;
            }
            return true;
        }

        public bool deleteVoter(int vid)
        {
            try
            {
                voter vobj = cxt.voters.Find(vid);
                cxt.voters.Remove(vobj);
                cxt.SaveChanges();
            }
            catch
            {
                return false;
            }
            return true;
        }

        public List<voter> getVoterList()
        {
            try
            {
                return cxt.voters.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
    }
}
