using System.Text.RegularExpressions;

namespace gacha.DTO
{
    public class machineData_DTO
    {
        public int MachineId { get; set; }
        public string MachineName { get; set; }
        public int TrackCount { get; set; }
//        select rechargeDate, count(*) from rechargeList
//group by rechargeDate

//select  MONTH(rechargeDate) AS Month, count(*) from rechargeList
//group by MONTH(rechargeDate)

//SELECT MONTH(rechargeDate) AS Month, COUNT(*) AS TotalCount
//FROM rechargeList
//GROUP BY MONTH(rechargeDate)
//ORDER BY Month;

    }
}
