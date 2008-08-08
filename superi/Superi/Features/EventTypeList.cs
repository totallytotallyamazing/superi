using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using Superi.Common;

namespace Superi.Features
{
    public class EventTypeList:List<EventType>
    {
        public EventTypeList(bool GetAll)
        {
            if (GetAll)
            {
                DbDataReader dr = AppData.ExecStoredProcedure("EventTypes_Get", null);
                if (dr != null && dr.HasRows)
                    Load(dr);
            }
        }

        public EventTypeList(DataTable dt)
        {
            Load(dt);
        }

        public EventTypeList(DbDataReader dr)
        {
            Load(dr);
        }

        public void Load(DataTable dt)
        {
            if (dt.Rows.Count > 0)
                foreach (DataRow row in dt.Rows)
                {
                    Add(new EventType(row));
                }
        }

        public void Load(DbDataReader dr)
        {
            if (dr.HasRows)
                while (dr.Read())
                {
                    Add(new EventType(dr));
                }
            dr.Close();
        }

    }
}
