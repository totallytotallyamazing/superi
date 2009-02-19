using System.Collections.Generic;
using System.Data.Common;
using Superi.Common;

namespace Superi.Features
{
    public class AttachableFilesResource : Dictionary<string, AttachableFile>
    {
        private int id = int.MinValue;

        public int Id
        {
            get { return id; }
        }

        public AttachableFilesResource()
        {

        }

        public AttachableFilesResource(int Id)
        {
            ParameterList pList = new ParameterList();
            pList.Add(new AppDbParameter("fileId", Id));

            DbDataReader dr = AppData.ExecStoredProcedure("AttachableFiles_Get", pList);
            Load(dr);

        }

        public void Load(DbDataReader dr)
        {
            if (dr.HasRows)
                while (dr.Read())
                    Add(dr["Language"].ToString(), new AttachableFile(dr));
        }

        public void Save()
        {
            if (id > 0)
                foreach (AttachableFile attachableFile in Values)
                    attachableFile.Save();
            else
            {
                DbDataReader dr = AppData.ExecStoredProcedure("AttachableFiles_GetMaxFileId", null);
                if (dr.HasRows && dr.Read())
                {
                    id = (int)dr["FileID"] + 1;
                    foreach (AttachableFile attachableFile in Values)
                    {
                        attachableFile.FileId = id;
                        attachableFile.Save();
                    }
                }
            }
        }

        public void Clean(string Folder)
        {
            foreach (AttachableFile file in this.Values)
            {
                System.IO.File.Delete(Folder + file.FileName);
                file.Remove();
            }
            Clear();
        }
   }
}
