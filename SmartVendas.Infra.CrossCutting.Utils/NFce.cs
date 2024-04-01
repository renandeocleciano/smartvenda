using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vinco.iContNFe.NFeIntegratorInterOp;
using Vinco.iContNFe.NFeIntegratorInterOp.Interface;

namespace SmartVendas.Infra.CrossCutting.Utils
{
    public class NFce
    {
        public void EmitirNota()
        {
            NFeIntegrator oNFe = new NFeIntegrator();

            //Informa o local onde os caches serão mantidos, o cache é excencial para emissão
            //em contingencia. É interessante no caso do uso de IIS, separar o cache em pastas
            //diferentes entre as aplicações web, pois o cache de regras é por empresa.
            oNFe.CacheFolder = AppDomain.CurrentDomain.BaseDirectory;

            //Seta o IdKey Empresa, esta propriedade permite setar qual empresa vai emitir NFe
            //o uso dessa propriedade elimina o uso do arquivo Empresa.Config, este valor é encontrado no portal do iContNFe, no cadastro de empresas.
            oNFe.IdKeyEmpresa = "4e51fcb2-702d-4740-84a2-e2f7b4aeb5d5";

            //Define que DLL esta em modo normal de emissão, esse modo não esta relacionado diretamente com a contingencia da NFe
            oNFe.Contingencia = false;

            //Define se os erros serão //lançados// para o programa chamador
            //ou se eles retornarão na propriedade Error das interfaces de retorno
            //Se utilizado como True, o erro aparecerá no `On Erro Goto`
            oNFe.Throwable = true;

            //Inicializa a DLL de InterOp
            oNFe.Start();

            //Set o IdKey do sistema
            //Este valor é contrado no Config Extractor no cadastro de sistemas.
            oNFe.SetIdKeySistema("0d2f0c11-c50f-4d63-9dd8-66903b0e4e3e");

            //Set de configurações de emissão: ambiente, impressão, finalidade, tipo de emisão
            oNFe.SetEnvironment(2, 1, 1, 1);

            //Set do tipo de nota, entrada ou saida
            oNFe.SetTipoNota(1);

            //Set do endereço no file system onde as NFe//s autorizadas serão armazenadas
            oNFe.EnderecoAutorizada = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Autorizada");

            //Define no numero de copias que serão impressas
            oNFe.SetNumeroCopias(1);

            //Define se a DLL imprimirá diretamenta para a impressão Padrão do windows
            oNFe.PrintToDefaultPrinter = false;

            oNFe.ClearParams();

            //No exemplo utlizado, existe somente 1 filtro:
            //- um com o numero da Nota Fiscal no sistema
            //Os filtros devem ser alimentados na mesma ordem que eles foram criados
            //no ConfigExtractor

            //Adiciona o valor no filtro
            oNFe.AddParams("081988");

            IRetornoAutorizar retorno = oNFe.Autorizar();

            IErroXSD[] erros = oNFe.GetErroXSD();

            if (erros != null && erros.Length > 0)
            {
                for (int i = 0; i < erros.Length; i++)
                {

                    //erros[i].Descricao, erros[i].Titulo
                }
            }

            if (retorno.cStat == 100)
            {
                //Se o cStat for igual a 100 isso indica que a nota foi autorizada com sucesso
                //nesse momento podemos armazenar todos os dados no sistema
                //retorno.ChaveNFe -> Chave da NFe
                //retorno.DataRecebimento -> Data da Autorização
                //retorno.Protocolo -> numero do protocolo
                //retorno.XMLProc -> XML da NF-e com o protocolo de autorização
                //retorno.PDF -> Binario com o PDF
                //"Protocolo: " + retorno.Protocolo

                //Verifica se deu erro no envio do email, como o email só em viando no caso da NF-e que autorizada
                //só é necessario veirificar aqui
                //esse erro não interfere no processo de autorização
                if (!string.IsNullOrEmpty(retorno.ErrorEnvioEmail))
                {
                    //"Erro no email: " + retorno.ErrorEnvioEmail
                }
            }
            else
            {
                //Caso contrario indica qual foi o motivo da rejeição.
                //"Mensagem: " + retorno.xMotivo
            }

        }
    }
}
