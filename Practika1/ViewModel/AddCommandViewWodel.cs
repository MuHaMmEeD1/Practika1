using Practika1.RCommand;
using Practika1.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practika1.ViewModel
{
    public class AddCommandViewWodel
    {

        public AddCommentView AddCommentView { get; set; }

        public RealyyCommand AddCommand { get; set; }
        public RealyyCommand CanleCommand { get; set; }



        public AddCommandViewWodel(AddCommentView addCommentView)
        {
            AddCommentView = addCommentView;

            CanleCommand = new RealyyCommand((object? par) => { AddCommentView.Close(); });
        }



    }
}
