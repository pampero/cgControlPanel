using System;
using Model;

namespace CGControlPanel.Account
{
    public partial class Login : BasePage
    {
        UnitOfWork unitOfWork = new UnitOfWork();

        protected void Page_Load(object sender, EventArgs e)
        {
          //  var job = unitOfWork.JobsRepository.GetByID(1);
        }
    }
}
