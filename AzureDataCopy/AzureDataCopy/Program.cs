using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management;

namespace AzureDataCopy
{
    class Program
    {
        
       static void Main(string[] args)
        {
            string strCmdText;
            string[] Source = {
            "https://kjasiaapp.blob.core.windows.net/dcppdfcontainer/2017/06/17123004562/20000105/1001_retinareport.pdf",
            "https://kjasiaapp.blob.core.windows.net/dcppdfcontainer/2017/06/17010504426/20000105/104_retinareport.pdf",
            "https://kjasiaapp.blob.core.windows.net/dcppdfcontainer/2017/06/30064934589/20000105/WM 24203_retinareport.pdf",
            "https://kjasiaapp.blob.core.windows.net/dcppdfcontainer/2017/06/21071204088/20000105/WM 22880_retinareport.pdf",
            "https://kjasiaapp.blob.core.windows.net/dcppdfcontainer/2017/06/30013204493/20000105/WM 7736_retinareport.pdf",
            "https://kjasiaapp.blob.core.windows.net/dcppdfcontainer/2017/06/21071734236/20000105/WM 11095_retinareport.pdf",
            "https://kjasiaapp.blob.core.windows.net/dcppdfcontainer/2017/06/21072034362/20000105/WM 7009_retinareport.pdf",
            "https://kjasiaapp.blob.core.windows.net/dcppdfcontainer/2017/06/21073734742/20000105/WM 24218_retinareport.pdf",
            "https://kjasiaapp.blob.core.windows.net/dcppdfcontainer/2017/06/27060604295/20000105/WM 24226_retinareport.pdf",
            "https://kjasiaapp.blob.core.windows.net/dcppdfcontainer/2017/07/5063404511/20000105/WM 19335_retinareport.pdf",
            "https://kjasiaapp.blob.core.windows.net/dcppdfcontainer/2017/07/10074104235/20000105/WM 19348_retinareport.pdf",
            "https://kjasiaapp.blob.core.windows.net/dcppdfcontainer/2017/07/10074234513/20000105/WM 5528_retinareport.pdf",
            "https://kjasiaapp.blob.core.windows.net/dcppdfcontainer/2017/07/14072703798/20000105/RS 13201_retinareport.pdf",
            "https://kjasiaapp.blob.core.windows.net/dcppdfcontainer/2017/07/17070904230/20000105/WM 24264_retinareport.pdf",
            "https://kjasiaapp.blob.core.windows.net/dcppdfcontainer/2017/07/17071304406/20000105/WM 24263_retinareport.pdf",
            "https://kjasiaapp.blob.core.windows.net/dcppdfcontainer/2017/08/10040533512/20000105/RS 13301_retinareport.pdf",
            "https://kjasiaapp.blob.core.windows.net/dcppdfcontainer/2017/08/10040433621/20000105/RS 13302_retinareport.pdf",
            "https://kjasiaapp.blob.core.windows.net/dcppdfcontainer/2017/08/10043534554/20000105/RS 13303_retinareport.pdf",
            "https://kjasiaapp.blob.core.windows.net/dcppdfcontainer/2017/08/10044404036/20000105/RS 13304_retinareport.pdf",
            "https://kjasiaapp.blob.core.windows.net/dcppdfcontainer/2017/08/10045104258/20000105/RS 13305_retinareport.pdf",
            "https://kjasiaapp.blob.core.windows.net/dcppdfcontainer/2017/08/10062504014/20000105/RS 13306_retinareport.pdf",
            "https://kjasiaapp.blob.core.windows.net/dcppdfcontainer/2017/08/10063634188/20000105/RS 13308_retinareport.pdf",
            "https://kjasiaapp.blob.core.windows.net/dcppdfcontainer/2017/08/10064333313/20000105/RS 13310_retinareport.pdf",
            "https://kjasiaapp.blob.core.windows.net/dcppdfcontainer/2017/08/10065433647/20000105/RS 13311_retinareport.pdf",
            "https://kjasiaapp.blob.core.windows.net/dcppdfcontainer/2017/08/10070204129/20000105/RS 13313_retinareport.pdf",
            "https://kjasiaapp.blob.core.windows.net/dcppdfcontainer/2017/08/10070833498/20000105/RS 13314_retinareport.pdf",
            "https://kjasiaapp.blob.core.windows.net/dcppdfcontainer/2017/08/15072134524/20000105/RS 13315_retinareport.pdf",
            "https://kjasiaapp.blob.core.windows.net/dcppdfcontainer/2017/08/10072803938/20000105/RS 13316_retinareport.pdf",
            "https://kjasiaapp.blob.core.windows.net/dcppdfcontainer/2017/08/31073533863/20000105/WM 23093_retinareport.pdf",
            "https://kjasiaapp.blob.core.windows.net/dcppdfcontainer/2017/08/10081504463/20000105/WM 4181_retinareport.pdf",
            "https://kjasiaapp.blob.core.windows.net/dcppdfcontainer/2017/08/10082604303/20000105/WM 10136_retinareport.pdf",
            };

            string[] Dest =
            {
            "https://dcpintegrated.blob.core.windows.net/pdfsastest/20009594/2018/11/23/636785869692483014/1001_retinareport.pdf",
            "https://dcpintegrated.blob.core.windows.net/pdfsastest/20009594/2018/11/23/636785869993405199/104_retinareport.pdf",
            "https://dcpintegrated.blob.core.windows.net/pdfsastest/20009594/2018/11/23/636785877533293156/WM 24203_retinareport.pdf",
            "https://dcpintegrated.blob.core.windows.net/pdfsastest/20009594/2018/11/23/636785877621575336/WM 22880_retinareport.pdf",
            "https://dcpintegrated.blob.core.windows.net/pdfsastest/20009594/2018/11/23/636785878131073286/WM 7736_retinareport.pdf",
            "https://dcpintegrated.blob.core.windows.net/pdfsastest/20009594/2018/11/23/636785878393066761/WM 11095_retinareport.pdf",
            "https://dcpintegrated.blob.core.windows.net/pdfsastest/20009594/2018/11/23/636785878814702672/WM 7009_retinareport.pdf",
            "https://dcpintegrated.blob.core.windows.net/pdfsastest/20009594/2018/11/23/636785879171509845/WM 24218_retinareport.pdf",
            "https://dcpintegrated.blob.core.windows.net/pdfsastest/20009594/2018/11/23/636785879547620943/WM 24226_retinareport.pdf",
            "https://dcpintegrated.blob.core.windows.net/pdfsastest/20009594/2018/11/23/636785879835891781/WM 19335_retinareport.pdf",
            "https://dcpintegrated.blob.core.windows.net/pdfsastest/20009594/2018/11/23/636785880203946988/WM 19348_retinareport.pdf",
            "https://dcpintegrated.blob.core.windows.net/pdfsastest/20009594/2018/11/23/636785880606975964/WM 5528_retinareport.pdf",
            "https://dcpintegrated.blob.core.windows.net/pdfsastest/20009594/2018/11/23/636785880979981601/RS 13201_retinareport.pdf",
            "https://dcpintegrated.blob.core.windows.net/pdfsastest/20009594/2018/11/23/636785881300461583/WM 24264_retinareport.pdf",
            "https://dcpintegrated.blob.core.windows.net/pdfsastest/20009594/2018/11/23/636785881661737058/WM 24263_retinareport.pdf",
            "https://dcpintegrated.blob.core.windows.net/pdfsastest/20009593/2018/11/23/636785881893926865/RS 13301_retinareport.pdf",
            "https://dcpintegrated.blob.core.windows.net/pdfsastest/20009593/2018/11/23/636785882229686340/RS 13302_retinareport.pdf",
            "https://dcpintegrated.blob.core.windows.net/pdfsastest/20009593/2018/11/23/636785882560379031/RS 13303_retinareport.pdf",
            "https://dcpintegrated.blob.core.windows.net/pdfsastest/20009593/2018/11/23/636785882912765565/RS 13304_retinareport.pdf",
            "https://dcpintegrated.blob.core.windows.net/pdfsastest/20009593/2018/11/23/636785883444032047/RS 13305_retinareport.pdf",
            "https://dcpintegrated.blob.core.windows.net/pdfsastest/20009593/2018/11/23/636785883860657576/RS 13306_retinareport.pdf",
            "https://dcpintegrated.blob.core.windows.net/pdfsastest/20009593/2018/11/23/636785884194120196/RS 13308_retinareport.pdf",
            "https://dcpintegrated.blob.core.windows.net/pdfsastest/20009593/2018/11/23/636785884484943766/RS 13310_retinareport.pdf",
            "https://dcpintegrated.blob.core.windows.net/pdfsastest/20009593/2018/11/23/636785884870014820/RS 13311_retinareport.pdf",
            "https://dcpintegrated.blob.core.windows.net/pdfsastest/20009593/2018/11/23/636785885151470697/RS 13313_retinareport.pdf",
            "https://dcpintegrated.blob.core.windows.net/pdfsastest/20009593/2018/11/23/636785885613433764/RS 13314_retinareport.pdf",
            "https://dcpintegrated.blob.core.windows.net/pdfsastest/20009593/2018/11/23/636785885944148800/RS 13315_retinareport.pdf",
            "https://dcpintegrated.blob.core.windows.net/pdfsastest/20009593/2018/11/23/636785886337491076/RS 13316_retinareport.pdf",
            "https://dcpintegrated.blob.core.windows.net/pdfsastest/20009593/2018/11/23/636785886816473218/WM 23093_retinareport.pdf",
            "https://dcpintegrated.blob.core.windows.net/pdfsastest/20009593/2018/11/23/636785887178941423/WM 4181_retinareport.pdf",
            "https://dcpintegrated.blob.core.windows.net/pdfsastest/20009593/2018/11/23/636785887516625018/WM 10136_retinareport.pdf"

            };

            string SourceKey = "nA1XwHsi31dn7nFDnCmiWAdtbADr1DYD5OUn9R3vsZbo3FP2wibVVnlzJ4Q6/ZI01v8YdjLvZ8cycSbJweFISQ==";
            string DestKey = "u3np+WCtOJYSwawiVpb4hpvmzNfiwPDE92vf97smZWT73WsdtldjrFZpldQa2O4eI9eaSvqZyEGsjCjSV6Lf9A==";

               //strCmdText = "/k cd C:/Program Files (x86)/Microsoft SDKs/Azure/AzCopy";
            for (Int64 i= 0; i<2;i++)
            {
                strCmdText = null;
                strCmdText = "/k cd C:/Program Files (x86)/Microsoft SDKs/Azure/AzCopy" + "& AzCopy /Source:\"" +Source[i]+ "\" /Dest:\""+Dest[i]+ "\" /SourceKey:"+SourceKey+ " /DestKey:"+DestKey+ "  /Y /V:C:/Desktop/testServer/azcopy_" + System.DateTime.Now.ToShortDateString() + ".log";
                System.Diagnostics.Process.Start("CMD.exe", strCmdText);
                System.Threading.Thread.Sleep(7000);
                Array.ForEach(Process.GetProcessesByName("cmd"), x => x.Kill());
                strCmdText = null;
           
            }
           // System.Diagnostics.Process.Start("CMD.exe", strCmdText);
        }


    }
}
