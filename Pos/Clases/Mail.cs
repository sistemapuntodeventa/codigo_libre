using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Mail;
using System.Net;
using System.Collections;
using Pos.Coneccion;
using System.Data;

namespace Pos.Clases
{
    class Mail
    {
        private string host;
        private int port;
        private string user;
        private string password;

        public Mail()
        {
            try
            {
                List<object> parametros = ParametroTR.ConsultarInt("20,21,22,23");
                this.host = parametros[0].ToString();
                this.port = Convert.ToInt32(parametros[1]);
                this.user = parametros[2].ToString();
                this.password = parametros[3].ToString();
            }
            catch (Exception e)
            {
                Mensaje.error(e.Message);
            }
        }

        public void enviarCorreoError(int idCaja, string mensaje)
        {
            System.Threading.Thread errorThread = new System.Threading.Thread(
            new System.Threading.ThreadStart(() =>
            {
                try
                {
                    string empresa = EmpresaTR.obtenerNombreEmpresa();
                    this.enviarError("Error al sincronizar " + empresa + " (" + Global.idEmpresa + ")","<strong>Caja:</strong>" + idCaja + "<br/><strong>Error:</strong>" + mensaje);
                }
                catch (Exception) { }
            }));
            errorThread.Start();
        }

        public bool enviarError(string asunto, string contenido,string archivo = null)
        {
            return this.enviarCorreo(this.user, asunto, contenido,archivo);
        }

        public bool enviarCorreo(string para, string asunto, string contenido, string archivo = null)
        {
            MailMessage theMailMessage = new MailMessage(this.user, para);
            theMailMessage.Subject = asunto;
            theMailMessage.Body = contenido;

            if (!String.IsNullOrEmpty(archivo))
            {
                Attachment imagen = new Attachment(archivo);
                theMailMessage.Attachments.Add(imagen);
            }

            SmtpClient theClient = new SmtpClient
            {
                Host = this.host,
                Port = this.port,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(this.user, this.password)
            };
            theMailMessage.IsBodyHtml = true;
            theClient.Send(theMailMessage);
            return true;
        }

        public string datosAdicionales(DataTable datosAdicionales)
        {
            return @"
				<table style='border-collapse:collapse;' border='1'>
					<tr>
						<th colspan='3' style='background-color:#79A8BE;color:white;padding:5px 0px 5px 0px;'>Datos Adicionales</td>
					</tr>
					<tr>
						<td style='width:180px;'>Pendiente sin facturar</td>
						<td style='width:100px;' align='center'>$" + datosAdicionales.Rows[0]["pendiente"].ToString() + @"</td>
					</tr>
					<tr>
						<td>Total Nota de Crédito</td>
						<td align='center'>$" + datosAdicionales.Rows[0]["notaCredito"].ToString() + @"</td>
					</tr>
					<tr>
						<td>Total documento no autorizado</td>
						<td align='center'>$" + datosAdicionales.Rows[0]["dna"].ToString() + @"</td>
					</tr>
				</table>";
        }

        public string resumenGeneral(DataTable resumenGeneral)
        {
            return @"
				<table style='border-collapse:collapse;' border='1'>
					<tr>
						<th colspan='3' style='background-color:#79A8BE;color:white;padding:5px 0px 5px 0px;'>Resumen General</td>
					</tr>
					<tr>
						<td style='width:180px;'>Subtotal Facturado</td>
						<td style='width:100px;' align='center'>$" + resumenGeneral.Rows[0]["subtotal"].ToString() + @"</td>
					</tr>
					<tr>
						<td>IVA</td>
						<td align='center'>$" + resumenGeneral.Rows[0]["iva"].ToString() + @"</td>
					</tr>
					<tr>
						<td>Servicio</td>
						<td align='center'>$" + resumenGeneral.Rows[0]["servicio"].ToString() + @"</td>
					</tr>
			        <tr>
				        <td>Descuento</td>
				        <td align='center'>$" + resumenGeneral.Rows[0]["descuento"].ToString() + @"</td>
			        </tr>
					<tr>
						<td style='font-weight:bold; text-decoration:underline;'>Total</td>
						<td style='font-weight:bold; text-decoration:underline;' align='center'>$" + resumenGeneral.Rows[0]["total"].ToString() + @"</td>
					</tr>
					<tr>
						<td>Propina</td>
						<td align='center'>$" + resumenGeneral.Rows[0]["propina"].ToString() + @"</td>
					</tr>
				</table>";
        }

        public string resumenCobros(DataTable resumenCobros)
        {
            return @"<table style='border-collapse:collapse;' border='1'>
                        <tr>
	                        <th colspan='3' style='background-color:#79A8BE;color:white;padding:5px 0px 5px 0px;'>Resumen de Cobros</td>
                        </tr>
                        <tr>
	                        <td style='width:180px;'>Efectivo</td>
	                        <td style='width:100px;' align='center'>$" + resumenCobros.Rows[0]["efectivo"].ToString() + @"</td>
                        </tr>
                        <tr>
	                        <td>Tarjeta</td>
	                        <td align='center'>$" + resumenCobros.Rows[0]["tarjeta"].ToString() + @"</td>
                        </tr>
                        <tr>
	                        <td>Cheque</td>
	                        <td align='center'>$" + resumenCobros.Rows[0]["cheque"].ToString() + @"</td>
                        </tr>
                        <tr>
	                        <td>Retenci&oacute;n</td>
	                        <td align='center'>$" + resumenCobros.Rows[0]["retencion"].ToString() + @"</td>
                        </tr>
                        <tr>
	                        <td style='font-weight:bold; text-decoration:underline;'>Total Cobrado</td>
	                        <td style='font-weight:bold; text-decoration:underline;' align='center'>$" + resumenCobros.Rows[0]["total_cobrado"].ToString() + @"</td>
                        </tr>
                        <tr>
	                        <td>PENDIENTE</td>
	                        <td align='center'>$" + resumenCobros.Rows[0]["pendiente"].ToString() + @"</td>
                        </tr>
                        </table>";
        }
        public string contenidoCierreCaja(int idCaja, bool cierreManual)
        {
            DataTable datosAdicionales = MailTR.datosAdicionales(idCaja, General.getComputerName(), Global.idEmpleado);
            DataTable resumenGeneral = MailTR.resumenGeneral(idCaja);
            DataTable ventasCategoria = MailTR.ventaCategoria(idCaja);
            DataTable resumenCobros = MailTR.resumenCobros(idCaja);
            DataTable redesCobro = MailTR.resumenRedesCobro(idCaja);

            string data = @"<html>
	                    <head>
		                    <title>Cierre de Caja Punto de Venta</title>
	                    </head>
	                    <body style='font-family:Helvetica, sans-serif; color:black;'>

		                    <div style='width:100%; float:left; padding-bottom:30px;'>
			                    <img style='float:left; margin-right:30px;' src='' alt='Logo Contífico' title='Contífico' width='160' height='50'/>
			
			                    <div style='text-align:center; min-width:160px; float:left; border-style:solid; border-width:1px; margin-left:30px;'>
				                    <div style='font-size:10px; padding:5px; color:white; background-color:green;'><b>Total cobrado en el año</b></div>
				                    <div style='font-size:14px; padding:0px 10px 0px 10px;'>
					                    <b style='font-size:16px;'>$</b><span>" + datosAdicionales.Rows[0]["ventasAnio"].ToString() + @"</span>
				                    </div>
			                    </div>
			
			                    <div style='text-align:center; min-width:160px; float:left; border-style:solid; border-width:1px; margin-left:10px;'>
				                    <div style='font-size:10px; padding:5px; color:white; background-color:green;'><b>Igual fecha año pasado</b></div>
				                    <div style='font-size:14px; padding:0px 10px 0px 10px;'>
					                    <b style='font-size:16px;'>$</b><span>" + datosAdicionales.Rows[0]["ventasAnioPasado"].ToString() + @"</span>
				                    </div>
			                    </div>
		                    </div>

		                    Estimado(a), se detalla a continuación el cierre de caja n° " + idCaja + @" del punto de venta de " + datosAdicionales.Rows[0]["direccion"].ToString() + @".
		                    </br>
		                    </br>

		                    <table>
			                    <tr>
				                    <td style='font-weight:bold;'>Fecha:</td>
				                    <td>"+ DateTime.Now.ToString() +@"</td>
			                    </tr>
			                    <tr>
				                    <td style='font-weight:bold;'>Cajero:</td>
				                    <td>" + datosAdicionales.Rows[0]["cajero"].ToString() + @"</td>
			                    </tr>
		                    </table>
		                    <br/>
                            <div>
                                <div style='float:left; padding-right:20px;'>" + this.resumenGeneral(resumenGeneral) + @"</div>
                                <div>" + this.resumenCobros(resumenCobros) + @"</div>
                            </div>" + this.resumenManual(resumenCobros,cierreManual) + @"
                            <h3 style='font-size:20px; margin-bottom:2; margin-top:20px;'>Ventas por Categor&iacute;a</h3>
		                    <table style='border-collapse:collapse;' border='1'>
			                    <tr style='background-color:#79A8BE;color:white;'>
				                    <th style='width:180px;'>Categor&iacute;a</td>
				                    <th style='width:100px;'>Subtotal</td>
				                    <th style='width:100px;'>Descuento</td>
				                    <th style='width:100px;'>IVA</td>
				                    <th style='width:100px;'>Total</td>
			                    </tr>";

                            foreach (DataRow fila in ventasCategoria.Rows)
                            {
                                data += @"<tr align='center'>
				                            <td align='left' style='width:180px;font-weight:bold;'>" + fila["nombre"] + @"</td>
				                            <td>$" + fila["subtotal"] + @"</td>
				                            <td>$" + fila["descuento"] + @"</td>
				                            <td>$" + fila["iva"] + @"</td>
				                            <td>$" + fila["total"] + @"</td>
			                            </tr>";
                            }

			               data += @"
		                    </table>
                             <h3 style='font-size:20px; margin-bottom:2; margin-top:20px;'>Redes de Cobro</h3>
		                    <table style='border-collapse:collapse;' border='1'>
			                    <tr style='background-color:#79A8BE;color:white;'>
				                    <th style='width:180px;'>Red</td>
				                    <th style='width:100px;'>Subtotal0</td>
                                    <th style='width:100px;'>Subtotal12</td>
				                    <th style='width:100px;'>Descuento</td>
				                    <th style='width:100px;'>IVA</td>
                                    <th style='width:100px;'>Servicio</td>
				                    <th style='width:100px;'>Total</td>
                                    <th style='width:100px;'>Propina</td>
			                    </tr>";

                           foreach (DataRow fila in redesCobro.Rows)
                           {
                               data += @"<tr align='center'>
				                            <td align='left' style='font-weight:bold;'>" + fila["red"] + @"</td>
				                            <td>$" + fila["subtotal0"] + @"</td>
				                            <td>$" + fila["subtotal12"] + @"</td>
				                            <td>$" + fila["descuento"] + @"</td>
				                            <td>$" + fila["iva"] + @"</td>
                                            <td>$" + fila["Servicio"] + @"</td>
                                            <td>$" + fila["Total"] + @"</td>
                                            <td>$" + fila["Propina"] + @"</td>
			                            </tr>";
                           }

                           data += @"
		                    </table><br/>" + this.datosAdicionales(datosAdicionales) +
	                    @"</body>
                    </html>";
                           return data;
        }

        private string resumenManual(DataTable resumenCobros, bool cierreManual)
        {
            if (!cierreManual) return "";
            return @"   <h3 style='font-size:20px; margin-bottom:2; margin-top:20px;'>Valores Manuales</h3>
                        <table style='border-collapse:collapse;' border='1'>
                        <tr>
	                        <th colspan='3' style='background-color:#79A8BE;color:white;padding:5px 0px 5px 0px;'>Valores</td>
                        </tr>
                        <tr>
	                        <td style='width:180px;'>Efectivo Manual</td>
	                        <td style='width:100px;' align='center'>$" + resumenCobros.Rows[0]["efectivo_manual"].ToString() + @"</td>
                        </tr>
                        <tr>
	                        <td style='width:180px;'>Efectivo Sistema</td>
	                        <td style='width:100px;' align='center'>$" + resumenCobros.Rows[0]["efectivo"].ToString() + @"</td>
                        </tr>
                        <tr>
	                        <td>Diferencia</td>
	                        <td style='font-weight:bold;' align='center'>$" + resumenCobros.Rows[0]["diferencia_efectivo"].ToString() + @"</td>
                        </tr>
                        <tr>
	                        <td>Cheque Manual</td>
	                        <td align='center'>$" + resumenCobros.Rows[0]["cheque_manual"].ToString() + @"</td>
                        </tr>
                        <tr>
	                        <td>Cheque Sistema</td>
	                        <td align='center'>$" + resumenCobros.Rows[0]["cheque"].ToString() + @"</td>
                        </tr>
                        <tr>
	                        <td>Diferencia</td>
	                        <td style='font-weight:bold;' align='center'>$" + resumenCobros.Rows[0]["diferencia_cheque"].ToString() + @"</td>
                        </tr>
                        </table>";
        }

        public string contenidoAperturaCaja(int idCaja)
        {
            DataTable datosApertura = MailTR.datosApertura(idCaja,General.getComputerName());
            string data = @"<html>
	                    <head>
		                    <title>Apertura de Caja Punto de Venta</title>
	                    </head>
	                    <body style='font-family:Helvetica, sans-serif; color:black;'>
		                    <div style='width:100%; float:left; padding-bottom:30px;'>
			                    <img style='float:left; margin-right:30px;' src='' alt='Logo Contífico' title='Contífico' width='160' height='50'/>
		                    </div>

		                    Estimado(a), se ha realizado la apertura de caja n° " + idCaja + @" del punto de venta de " + datosApertura.Rows[0]["direccion"].ToString() + @".
		                    <br/>
                            <br/>
		                    <table>
			                    <tr>
				                    <td style='font-weight:bold;'>Fecha:</td>
				                    <td>" + datosApertura.Rows[0]["fecha"].ToString() + @"</td>
			                    </tr>
			                    <tr>
				                    <td style='font-weight:bold;'>Cajero:</td>
				                    <td>" + datosApertura.Rows[0]["cajero"].ToString() + @"</td>
			                    </tr>
			                    <tr>
				                    <td style='font-weight:bold;'>Monto:</td>
				                    <td>" + datosApertura.Rows[0]["monto"].ToString() + @"</td>
			                    </tr>
		                    </table></body></html>
                           ";
            return data;
        }
    }
}
