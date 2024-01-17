using PortailTE44.Business.Services.Interfaces;
using PortailTE44.Common.Utils;

namespace PortailTE44.Business.Services
{
    public class TestApiEudonetService : ITestApiEudonetService
    {
        protected readonly EudoAPI _eudoAPI;
        public TestApiEudonetService(EudoAPI eudoAPI)
        {
            _eudoAPI = eudoAPI;
        }

        public bool GetTest()
        {
            _eudoAPI.Connect();
            string result = GetWorkManagerMailFromWorkId("123");
            _eudoAPI.Disconnect();
            return true;
        }

        public static string GetWorkManagerMailFromWorkId(string workId)
        {
            if (workId == null) return string.Empty;
            if (workId == string.Empty) return string.Empty;

            // First query the "affaires" table to retrive the work manager "FileId" (=primary key of the "contacts" table)
            // 1300 : DescId of the "affaires" table
            // 1318 : DescId of the "work manager" field
            // 1303 : DescId of the "Work number" field (the 'where')
            EudoAPI_Rootobject? ro_work = EudoAPI.QueryByCriteria(1300, new int[] { 1318 }, 1303, workId);
            // Ensure the next operation
#pragma warning disable CS8602
            if (ro_work == null) return string.Empty;
            if (ro_work.ResultData == null) return string.Empty;
            if (ro_work.ResultData.Rows == null) return string.Empty;
            if (ro_work.ResultData.Rows.Length != 0)
                if (ro_work.ResultData.Rows[0].Fields == null) return string.Empty;
            if (ro_work.ResultData.Rows[0].Fields.Length == 0) return string.Empty;
            if (ro_work.ResultData.Rows[0].Fields[0].DbValue == null) return string.Empty;
            string contactFileId = ro_work.ResultData.Rows[0].Fields[0].DbValue;
#pragma warning restore CS8602

            // Then get the full "contact" row for this "FileId"
            EudoAPI_Rootobject? ro_contact = EudoAPI.GetFile(200, contactFileId);
            // Ensure the next operation
#pragma warning disable CS8602
            if (ro_contact == null) return string.Empty;
            if (ro_contact.ResultData == null) return string.Empty;
            if (ro_contact.ResultData.Rows == null) return string.Empty;
            if (ro_contact.ResultData.Rows.Length != 0)
                if (ro_contact.ResultData.Rows[0].Fields == null) return string.Empty;
            if (ro_contact.ResultData.Rows[0].Fields.Length < 3) return string.Empty;
            if (ro_contact.ResultData.Rows[0].Fields[1].DbValue == null) return string.Empty;
            if (ro_contact.ResultData.Rows[0].Fields[2].DbValue == null) return string.Empty;
            string contactLName = ro_contact.ResultData.Rows[0].Fields[1].DbValue;
            string contactFName = ro_contact.ResultData.Rows[0].Fields[2].DbValue;
#pragma warning restore CS8602

            // Finally, send a complex custom query on the "contacts" table (inner join "adresses") to retrieve the email
            EudoAPI_Rootobject? ro_email = EudoAPI.QueryByCustoms(200, new int[] { 408 }, new int[] { 201, 202 }, new string[] { contactLName, contactFName });
            // Ensure the final operation
#pragma warning disable CS8602
            if (ro_email == null) return string.Empty;
            if (ro_email.ResultData == null) return string.Empty;
            if (ro_email.ResultData.Rows == null) return string.Empty;
            if (ro_email.ResultData.Rows.Length == 0) return string.Empty;
            if (ro_email.ResultData.Rows[0].Fields == null) return string.Empty;
            if (ro_email.ResultData.Rows[0].Fields.Length == 0) return string.Empty;
            if (ro_email.ResultData.Rows[0].Fields[0].DbValue == null) return string.Empty;
            string result = ro_email.ResultData.Rows[0].Fields[0].Value;


            return result;
#pragma warning restore CS8602
        }
    }
}
