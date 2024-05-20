using System.Diagnostics.Eventing.Reader;

namespace LabaCRUD.Pages.Models
{
    // public class Order
    // {
    //     public int Id { get; set; }
    //     public int ConractCode { get; set; }
    //     public string Ansewer {  get; set; }
    //     public string reason { get; set; }



    //public Order()
    //{   
    //    if(Amount/Salary<100)
    //    {
    //        Ansewer = "ПОЛНОСТЬЮ ОДОБРЕНО";
    //        reason = "В соответсвтвии с пунктом 1 настоящего Приказа";
    //    }
    //    else
    //    {
    //        if ((Salary >= 500000) && (Amount >= 100000000)) {
    //            Ansewer = "ОДОБРЕНО С ОГРАНИЧЕНИЯМИ";
    //            reason = "В соответсвтвии с пунктом 2 настоящего Приказа";
    //        }
    //        else
    //        {
    //            if (Amount / Salary * 3 / 120 < 1)
    //            {
    //                Ansewer = "ОДОБРЕНО ИПОТЕКОЙ ПОД 3%";
    //                reason = "В соответсвтвии с пунктом 3 настоящего Приказа";
    //            }
    //            else
    //            {
    //                Ansewer = "ПОЛНЫЙ ОТКАЗ";
    //                reason = "Запрашиваемыя сумма слишком большая и/или зарабатная плата слишком низкая";
    //            }
    //        }
    //    }




    public class Order
    {
        public int Id { get; set; }
        public int ContractId { get; set; }
        public string Answer { get; set; }
        public string Reason { get; set; }
        public Contract Contract { get; set; }
    }







}
