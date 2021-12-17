using CDOM;
using MSL;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services
{
    public class CodeGenerateService
    {
        /*
            Burda nezer
         */

        public void Execute( TDomain domain,ITemplate template )
        {
            var context = new Pipline.AppContext( )
                .AddProperty(Pipline.AppConstants.DOMAIN,domain)
                .AddProperty(Pipline.AppConstants.TEMPLATE,template);

            //burda ve ya diger yerde middleware-lerde duzelmelidir
            var app = new Pipline.AppBuilder( ).Build( context );

            //burda artiq bu app-i neyniyeceyimi fikirleshmeliyem
            //Bunu men Json formatinda geri qaytarmaliyam
            //Bunu sonradan cagiran CodeManagement-de orda artiq
            //Db-demi saxlasin yoxsa Git-e mi vursum bu sheyler ola biler
            //Hetda ordaki programda account-a gore db-yaradib ona gore scriptlerde
            //cixartmaq belke imkani olar biler ve ya o hisse burdada ola biler
            //amma ki bura stateless-dir yeni servicdir burda olmagi alinmir
            //amma diger terefdende burda olmagi meniqidir ki bura verecek axi scripti
            //diger terefden eger biz entity framework-le ishleyirikse belkede 
            //vermesede olar scripti
        }
    }
}
