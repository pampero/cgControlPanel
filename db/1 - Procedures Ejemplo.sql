USE [cgControlPanel]
GO
/****** Object:  StoredProcedure [dbo].[OP_PROCESO_FINAL_EXEC]    Script Date: 09/18/2012 17:42:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*

Ejemplo de uso

Declare @nTriggerId int
Declare @cParametro varchar(4000) 
Declare @xInput  xml 
Declare @xOutput  xml
Declare @xLog     xml
Declare @xReporteSalida  xml 
Declare	@nRows 	int
Declare @nRowsAfectados int
Declare @cStatus varchar(100)

Exec [OP_PROCESO_DIVBYZERO_EXEC]  	
				@nTriggerId OUT,
				@cParametro ,
				@xInput  , 
				@xOutput  OUT, 
				@xLog     OUT, 
				@xReporteSalida  OUT ,
				@nRows OUT,
				@nRowsAfectados OUT,
				@cStatus OUT

select	@xOutput  
select	@xLog     
select	@xReporteSalida  
select	@nRows
select	@nRowsAfectados 
select	@cStatus
*/

CREATE Procedure [dbo].[OP_PROCESO_DIVBYZERO_EXEC] 
	@nTriggerId int OUT,
	@cParametro varchar(4000),
	@xInput  xml , -- este eseDatos de input que limitan los registros a procesar
	@xOutput  xml OUT, -- XML de salida Output
	@xResultado xml OUT, -- Reporte de Salida resumenes etc.
	@xLogEjecucion     xml OUT, -- Log
	@nRowsAffected  int OUT, 
	@nRowsTotal int OUT,
	@cStatus varchar(100) OUT 
as

	Set nocount on


	Declare	@nId int

	WAITFOR DELAY '00:00:20'

	set @nId = 1/0
GO

/****** Object:  StoredProcedure [dbo].[OP_PROCESO_FINAL_EXEC]    Script Date: 09/18/2012 17:42:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*

Ejemplo de uso

Declare @nTriggerId int
Declare @cParametro varchar(4000) 
Declare @xInput  xml 
Declare @xOutput  xml
Declare @xLog     xml
Declare @xReporteSalida  xml 
Declare	@nRows 	int
Declare @nRowsAfectados int
Declare @cStatus varchar(100)

Exec [OP_PROCESO_WRONGPARAMETERS_EXEC]  	
				@nTriggerId OUT,
				@cParametro ,
				@xInput  , 
				@xOutput  OUT, 
				@xLog     OUT, 
				@xReporteSalida  OUT ,
				@nRows OUT,
				@nRowsAfectados OUT,
				@cStatus OUT

select	@xOutput  
select	@xLog     
select	@xReporteSalida  
select	@nRows
select	@nRowsAfectados 
select	@cStatus
*/

CREATE Procedure [dbo].[OP_PROCESO_WRONGPARAMETERS_EXEC] 
	@nTriggerId int OUT,
	@cParametro varchar(4000),
	@xOutput  xml OUT, -- XML de salida Output
	@xResultado xml OUT, -- Reporte de Salida resumenes etc.
	@xLogEjecucion     xml OUT, -- Log
	@nRowsAffected  int OUT, 
	@nRowsTotal int OUT,
	@cStatus varchar(100) OUT 
as

	Set nocount on


	Declare	@nId int

	WAITFOR DELAY '00:00:20'

GO


/****** Object:  StoredProcedure [dbo].[OP_PROCESO_EJEMPLO_EXEC]    Script Date: 08/27/2012 23:43:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*

Ejemplo de uso

Declare @cParametro varchar(4000) 
Declare @xInput  xml 
Declare @xParametrosInput xml
Declare @xOutput  xml
Declare @xLogEjecucion     xml
Declare @xResultado  xml 
Declare	@nRowsAffected int
Declare	@nRowsTotal int
Declare	@cStatus varchar(100)
Declare	@nTriggerId int

Exec OP_PROCESO_EJEMPLO_EXEC 
				@nTriggerId,
				@xParametrosInput,
				@xInput  , 
				@xOutput  OUT,  -- Salida de la tabla. Respuesta al xInput
				@xResultado  OUT, -- Resultado del negocio, html valido
				@xLogEjecucion OUT, 
				@nRowsAffected  OUT, 
				@nRowsTotal OUT,
				@cStatus OUT 				

select	@xOutput  
select	@xResultado
select	@xLogEjecucion
select	@nRowsAffected
select	@nRowsTotal
select	@cStatus
select	@xParametrosInput

*/
                
CREATE Procedure [dbo].[OP_PROCESO_EJEMPLO_EXEC] 

@nTriggerId int OUT,
@xParametrosInput xml,
@xInput  xml , -- Datos de input que limitan los registros a procesar
@xOutput  xml OUT, -- XML de salida Output
@xResultado xml OUT, -- Reporte de Salida resumenes etc.
@xLogEjecucion     xml OUT, -- Log
@nRowsAffected  int OUT, 
@nRowsTotal int OUT,
@cStatus varchar(100) OUT 

as

	Set nocount on
	
	WAITFOR DELAY '00:00:20'

	Declare	@nId int
	Declare	@nIdMax int

	Set	@nId 	= 1
	Set	@nIdMax = 10
	
	Set @cStatus = 'Anduvo OK'

	Set	@xLogEjecucion=  convert(varchar,getdate(),111) + ' ' + convert(varchar,getdate(),108) + ' Inicia proceso<BR />'


	set	@xLogEjecucion=  (select @xLogEjecucion , cast(convert(varchar,getdate(),111) + ' ' + convert(varchar,getdate(),108) + ' Crea Tabla Temporaria<BR />' as xml)
			for xml path (''))


	Create Table #OutPut
		(
		nId int,
		cCampo1 varchar(100),
		cCampo2 varchar(100),
		cCampo3 varchar(100),
		cCampo4 varchar(100),
		cCampo5 varchar(100),
		cCampo6 varchar(100),
		cCampo7 varchar(100),
		cCampo8 varchar(100),
		cCampo9 varchar(100),
		cCampo10 varchar(100),
		cEstado varchar(10),
		cComentario varchar(255)
		)

	Set	@xLogEjecucion=  (select @xLogEjecucion , cast( convert(varchar,getdate(),111) + ' ' + convert(varchar,getdate(),108) + ' Inicia LOOP<BR />' as xml)
			for xml path (''))

	While	@nId 	<= @nIdMax 
	Begin

		Insert	#OutPut
		Values
			(@nId ,
			'Campo 1 registro ' + convert(varchar,@nId),
			'Campo 2 registro ' + convert(varchar,@nId),
			'Campo 3 registro ' + convert(varchar,@nId),
			'Campo 4 registro ' + convert(varchar,@nId),
			'Campo 5 registro ' + convert(varchar,@nId),
			'Campo 6 registro ' + convert(varchar,@nId),
			'Campo 7 registro ' + convert(varchar,@nId),
			'Campo 8 registro ' + convert(varchar,@nId),
			'Campo 9 registro ' + convert(varchar,@nId),
			'Campo 10 registro ' + convert(varchar,@nId),
			'PENDIENTE',
			'Comentario ' + convert(varchar,@nId)
			)

		Set	@nId 	= @nId 	  + 1 
	End


	Set	@xLogEjecucion=  (select @xLogEjecucion ,  cast('<DTIME>' + convert(varchar,getdate(),111) + ' ' + convert(varchar,getdate(),108) + '</DTIME>' +
			'<CLOG>' + 'Finaliza LOOP' + '</CLOG>' as xml)
			for xml path (''))


	Set	@xLogEjecucion=  (select @xLogEjecucion ,  cast(convert(varchar,getdate(),111) + ' ' + convert(varchar,getdate(),108) + ' Inicia armado de Output<BR />' as xml)
			for xml path (''))


	Set	@xOutput  = 	(   
				Select 	*
				From 	#OutPut
				For Xml raw('tr'), elements
				)

	Set	@xLogEjecucion=  (select @xLogEjecucion , cast(convert(varchar,getdate(),111) + ' ' + convert(varchar,getdate(),108) + ' Finaliza armado de Output<BR />' as xml)
			for xml path (''))


	Set	@xLogEjecucion=  (select @xLogEjecucion ,  cast(convert(varchar,getdate(),111) + ' ' + convert(varchar,getdate(),108) + ' Inicia armado de resultado resumen<BR />' as xml)
			for xml path (''))

		Set	@xResultado  = (
					select cEstado as TD, count(*) as TD
					from 	#OutPut
					group by cEstado
					For Xml raw('tr'), elements
				 )


	Set	@xLogEjecucion=  (select @xLogEjecucion ,  cast(convert(varchar,getdate(),111) + ' ' + convert(varchar,getdate(),108) + ' Finaliza armado de resultado resumen<BR />' as xml)
			for xml path (''))



	Set	@xLogEjecucion=  (select @xLogEjecucion , cast(convert(varchar,getdate(),111) + ' ' + convert(varchar,getdate(),108) + ' Finaliza proceso<BR />' as xml)
			for xml path (''))

Select	@xResultado =  '
					<style type="text/css">
							BODY        { background-color : #FFFFFF; font-family : arial; text-align : left; color : black;}
							.comercial  { BORDER : 0 solid #000; width : 100%; margin : 0; border-collapse : collapse; border-spacing : 0;}
							.fecha      { BORDER : 0 solid #000;  width : 15%; font-size : 10pt; font-family : arial; background-color : #FFFFFF; text-align : left;}
							.titulo     { BORDER : 0 solid #000; width : 70%; font-size : 10pt; font-family : arial; background-color : #FFFFFF; text-align : center;}
							.Subtitulo  { BORDER : 0 solid #000; width : 70%; font-size : 10pt; font-family : arial; background-color : #FFFFFF; text-align : center;}
							.hora       { BORDER : 0 solid #000; width : 15%; font-size : 10pt; font-family : arial; background-color : #FFFFFF; text-align : right;}							
							.Columnas   { BORDER : 0 solid #000; font-size : 12pt; font-family : arial; background-color : #FFFFFF; text-align : center; border-bottom-width:1px}
							.Columna1   { BORDER : 0 solid #000; width : 15%;  font-size : 10pt; font-family : arial; background-color : #FFFFFF; text-align : left;}							
							.Rotulo     { BORDER : 0 solid #000; font-family : arial; font-size : 10pt; text-align : left;} 
							.Datos      { BORDER : 0 solid #000;  font-size : 8pt; font-family : arial; background-color : #FFFFFF; text-align : center; width ; border-bottom-width:1px;border-bottom-style:dotted}
							.DatosPequeño { BORDER : 0 solid #000;  font-size : 8pt; font-family : arial; background-color : #FFFFFF; text-align : Left; width ; border-bottom-width:1px;border-bottom-style:dotted}
							.RotuloTotal{ BORDER : 0 solid #000; font-family : arial; font-size : 15pt;  text-align : left; border-top-width:2px;border-top-style:solid} 
							.DatosTotal { BORDER : 0 solid #000;   font-size : 8pt; font-family : arial; background-color : #FFFFFF; text-align : center; border-top-width:2px;border-top-style:solid}
					</style>
				
			<table border="1" width="100%">
				<tr>
					<td class="fecha" style="width:15%" rowspan="2">24/08/2012 18:52</td>
					<td class="titulo" style="width:15%" rowspan="2"></td>
					<td class="hora" style="width:70%"><div style ="color: #E7281F" >Todas las sucursales</div></td>
				</tr>
				<tr>
					<td colspan="3"><br/></td>
				</tr>
			</table>
			<table class="comercial">
					<tr >
						<td class="Columna1" width="50%">Fecha Hora</td>
						<td class="Columna1" width="50%">Accion</td>
						<td class="Columnas" width="10%">Registros Afectados</td>								
					</tr>
					<tr>
							<td class="Rotulo">04:05</td>
							<td class="Rotulo">Creacion Tabla Temporaria</td>
							<td class="Datos">0</td>
					</tr>
					<tr>
							<td class="Rotulo">04:07</td>
							<td class="Rotulo">Llenado de Tabla Temporaria</td>
							<td class="Datos">1501</td>
					</tr>
					<tr>
							<td class="Rotulo">04:09</td>
							<td class="Rotulo">Completado de Campos</td>
							<td class="Datos">1501</td>
					</tr>
					<tr>
							<td class="Rotulo">04:15</td>
							<td class="Rotulo">Eliminar duplicados</td>
							<td class="Datos"><font color="red">12</font></td>
					</tr>
					<tr>
							<td class="Rotulo">04:19</td>
							<td class="Rotulo">Impactar solo Telefonos</td>
							<td class="Datos">120</td>
					</tr>
					<tr>
							<td class="Rotulo">04:21</td>
							<td class="Rotulo">Fin de proceso</td>
							<td class="Datos">0</td>
					</tr>
			</table>
			'
			
Set	@nRowsAffected = 500
Set	@nRowsTotal = 100


GO
/****** Object:  StoredProcedure [dbo].[OP_PROCESO_EJEMPLO_EXEC]    Script Date: 08/26/2012 13:57:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE Procedure [dbo].[OP_PROCESO_EJEMPLO_CONFIG] 

as

	Set nocount on
	
	SELECT '<?xml version="1.0" encoding="iso-8859-1" ?>
<CDIALOGO>
  <CAMPO>
    <CCLAVE>CTITULO1</CCLAVE>
    <CTIPO>TITULO</CTIPO>
    <CNOMBRE>0111- PROCESOS DE CUENTAS BANCARIAS</CNOMBRE>
    <LTITULO>1</LTITULO>
  </CAMPO>
  <CAMPO>
    <CCLAVE>CSEPARADOR1</CCLAVE>
    <CTIPO>SEPARADOR</CTIPO>
    <CNOMBRE>Parametros del proceso</CNOMBRE>
    <LTITULO>1</LTITULO>
  </CAMPO>
  <CAMPO>
    <CCLAVE>CCOMENTARIO</CCLAVE>
    <CTIPO>TPTEXTO</CTIPO>
    <CNOMBRE>Comentarios</CNOMBRE>
    <NLARGOMIN>1</NLARGOMIN>
    <NLARGOMAX>255</NLARGOMAX>
    <LVACIO>1</LVACIO>
    <LMODIFICABLE>1</LMODIFICABLE>
  </CAMPO>
  <CAMPO>
    <CCLAVE>CPRODUCTO</CCLAVE>
    <CTIPO>TPRADIO</CTIPO>
    <CDEFAULT>CCORR</CDEFAULT>
    <CCONTROLASOC>CCONCEPTO</CCONTROLASOC>
    <CNOMBRE>Producto a procesar</CNOMBRE>
    <VALORES>
      <VALOR>
        <CCLAVE>TARJETA</CCLAVE>
        <CTEXTO>Tarjetas de credito</CTEXTO>
      </VALOR>
      <VALOR>
        <CCLAVE>CCORR</CCLAVE>
        <CTEXTO>Cuenta Corriente</CTEXTO>
      </VALOR>
      <VALOR>
        <CCLAVE>CAHORRO</CCLAVE>
        <CTEXTO>Caja de Ahorro</CTEXTO>
      </VALOR>
    </VALORES>
  </CAMPO>
  <CAMPO>
    <CCLAVE>CPRODUCTOCHECK</CCLAVE>
    <CTIPO>TPCHECK</CTIPO>
    <CNOMBRE>Productos a procesar</CNOMBRE>
    <VALORES>
      <VALOR>
        <CCLAVE>TARJETACHECK</CCLAVE>
        <CTEXTO>Tarjetas de credito</CTEXTO>
      </VALOR>
      <VALOR>
        <CCLAVE>CCORRCHECK</CCLAVE>
        <CTEXTO>Cuenta Corriente</CTEXTO>
      </VALOR>
    </VALORES>
  </CAMPO>
  <CAMPO>
    <CCLAVE>CCONCEPTO</CCLAVE>
    <CTIPO>TPCOMBO</CTIPO>
    <CNOMBRE>Concepto a procesar</CNOMBRE>
    <VALORES>
      <VALOR>
        <CCLAVEASOC>CAHORRO</CCLAVEASOC>
        <CCLAVE>INT CH</CCLAVE>
        <CTEXTO>Generar Intereses</CTEXTO>
      </VALOR>
      <VALOR>
        <CCLAVEASOC>CAHORRO</CCLAVEASOC>
        <CCLAVE>MULTA CH</CCLAVE>
        <CTEXTO>Generar Multas</CTEXTO>
      </VALOR>
      <VALOR>
        <CCLAVEASOC>CCORR</CCLAVEASOC>
        <CCLAVE>INT CC</CCLAVE>
        <CTEXTO>Generar Intereses</CTEXTO>
      </VALOR>
      <VALOR>
        <CCLAVEASOC>CCORR</CCLAVEASOC>
        <CCLAVE>MULTA CC</CCLAVE>
        <CTEXTO>Generar Multas</CTEXTO>
      </VALOR>
      <VALOR>
        <CCLAVEASOC>CCORR</CCLAVEASOC>
        <CCLAVE>SALDOS CC</CCLAVE>
        <CTEXTO>Recalcular Saldos</CTEXTO>
      </VALOR>
      <VALOR>
        <CCLAVEASOC>TARJETA</CCLAVEASOC>
        <CCLAVE>REDOND TJ</CCLAVE>
        <CTEXTO>Corregir redondeos</CTEXTO>
      </VALOR>
      <VALOR>
        <CCLAVEASOC>TARJETA</CCLAVEASOC>
        <CCLAVE>PAG TJ</CCLAVE>
        <CTEXTO>Pago Minimo</CTEXTO>
      </VALOR>
    </VALORES>
  </CAMPO>
  <CAMPO>
    <CCLAVE>NMONTOMINIMO</CCLAVE>
    <CTIPO>TPREAL</CTIPO>
    <CNOMBRE>Monto minimo de interes</CNOMBRE>
    <LVACIO>1</LVACIO>
    <LMODIFICABLE>1</LMODIFICABLE>
    <NMINIMO>10.59</NMINIMO>
    <NMAXIMO>4000.53</NMAXIMO>
  </CAMPO>
  <CAMPO>
    <CCLAVE>NPERIODOS</CCLAVE>
    <CTIPO>TPENTERO</CTIPO>
    <CNOMBRE>Periodos a Procesar</CNOMBRE>
    <NMINIMO>1</NMINIMO>
    <NMAXIMO>1000</NMAXIMO>
    <LVACIO>1</LVACIO>
  </CAMPO>
  <CAMPO>
    <CCLAVE>CSEPARADOR2</CCLAVE>
    <CTIPO>SEPARADOR</CTIPO>
    <CNOMBRE>Rango de Fechas</CNOMBRE>
  </CAMPO>
  <CAMPO>
    <CCLAVE>DFECHADESDE</CCLAVE>
    <CTIPO>TPFECHA</CTIPO>
    <CCONTROLASOC>DFECHAHASTA</CCONTROLASOC>
    <CNOMBRE>Fecha Desde</CNOMBRE>
    <LVACIO>0</LVACIO>
    <DMINDATE>2012/01/01</DMINDATE>
    <DMAXDATE>2013/12/24</DMAXDATE>
  </CAMPO>
  <CAMPO>
    <CCLAVE>DFECHAHASTA</CCLAVE>
    <CTIPO>TPFECHA</CTIPO>
    <CNOMBRE>Fecha Hasta</CNOMBRE>
    <LVACIO>0</LVACIO>
    <DMINDATE>2012/01/01</DMINDATE>
    <DMAXDATE>2012/12/30</DMAXDATE>
  </CAMPO>
  <CAMPO>
    <CCLAVE>HORA</CCLAVE>
    <CTIPO>TPHORA</CTIPO>
    <CNOMBRE>Hora</CNOMBRE>
    <LVACIO>0</LVACIO>
    <HMINIMO>09:00:00</HMINIMO>
    <HMAXIMO>18:00:00</HMAXIMO>
  </CAMPO>
</CDIALOGO>'

GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE Procedure [dbo].[OP_PROCESO_QUARTZ_CONFIG] 

as

	Set nocount on
	
	SELECT '<?xml version="1.0" encoding="iso-8859-1" ?>
<CDIALOGO>
  <CAMPO>
    <CCLAVE>CTITULO1</CCLAVE>
    <CTIPO>TITULO</CTIPO>
    <CNOMBRE>0111- PROCESOS DE CUENTAS BANCARIAS</CNOMBRE>
    <LTITULO>1</LTITULO>
  </CAMPO>
  <CAMPO>
    <CCLAVE>CSEPARADOR1</CCLAVE>
    <CTIPO>SEPARADOR</CTIPO>
    <CNOMBRE>Parametros del proceso</CNOMBRE>
    <LTITULO>1</LTITULO>
  </CAMPO>
  <CAMPO>
    <CCLAVE>CCOMENTARIO</CCLAVE>
    <CTIPO>TPTEXTO</CTIPO>
    <CNOMBRE>Comentarios</CNOMBRE>
    <NLARGOMIN>1</NLARGOMIN>
    <NLARGOMAX>255</NLARGOMAX>
    <LVACIO>1</LVACIO>
    <LMODIFICABLE>1</LMODIFICABLE>
  </CAMPO>
  <CAMPO>
    <CCLAVE>CPRODUCTO</CCLAVE>
    <CTIPO>TPRADIO</CTIPO>
    <CDEFAULT>CCORR</CDEFAULT>
    <CCONTROLASOC>CCONCEPTO</CCONTROLASOC>
    <CNOMBRE>Producto a procesar</CNOMBRE>
    <VALORES>
      <VALOR>
        <CCLAVE>TARJETA</CCLAVE>
        <CTEXTO>Tarjetas de credito</CTEXTO>
      </VALOR>
      <VALOR>
        <CCLAVE>CCORR</CCLAVE>
        <CTEXTO>Cuenta Corriente</CTEXTO>
      </VALOR>
      <VALOR>
        <CCLAVE>CAHORRO</CCLAVE>
        <CTEXTO>Caja de Ahorro</CTEXTO>
      </VALOR>
    </VALORES>
  </CAMPO>
  <CAMPO>
    <CCLAVE>CPRODUCTOCHECK</CCLAVE>
    <CTIPO>TPCHECK</CTIPO>
    <CNOMBRE>Productos a procesar</CNOMBRE>
    <VALORES>
      <VALOR>
        <CCLAVE>TARJETACHECK</CCLAVE>
        <CTEXTO>Tarjetas de credito</CTEXTO>
      </VALOR>
      <VALOR>
        <CCLAVE>CCORRCHECK</CCLAVE>
        <CTEXTO>Cuenta Corriente</CTEXTO>
      </VALOR>
    </VALORES>
  </CAMPO>
  <CAMPO>
    <CCLAVE>CCONCEPTO</CCLAVE>
    <CTIPO>TPCOMBO</CTIPO>
    <CNOMBRE>Concepto a procesar</CNOMBRE>
    <VALORES>
      <VALOR>
        <CCLAVEASOC>CAHORRO</CCLAVEASOC>
        <CCLAVE>INT CH</CCLAVE>
        <CTEXTO>Generar Intereses</CTEXTO>
      </VALOR>
      <VALOR>
        <CCLAVEASOC>CAHORRO</CCLAVEASOC>
        <CCLAVE>MULTA CH</CCLAVE>
        <CTEXTO>Generar Multas</CTEXTO>
      </VALOR>
      <VALOR>
        <CCLAVEASOC>CCORR</CCLAVEASOC>
        <CCLAVE>INT CC</CCLAVE>
        <CTEXTO>Generar Intereses</CTEXTO>
      </VALOR>
      <VALOR>
        <CCLAVEASOC>CCORR</CCLAVEASOC>
        <CCLAVE>MULTA CC</CCLAVE>
        <CTEXTO>Generar Multas</CTEXTO>
      </VALOR>
      <VALOR>
        <CCLAVEASOC>CCORR</CCLAVEASOC>
        <CCLAVE>SALDOS CC</CCLAVE>
        <CTEXTO>Recalcular Saldos</CTEXTO>
      </VALOR>
      <VALOR>
        <CCLAVEASOC>TARJETA</CCLAVEASOC>
        <CCLAVE>REDOND TJ</CCLAVE>
        <CTEXTO>Corregir redondeos</CTEXTO>
      </VALOR>
      <VALOR>
        <CCLAVEASOC>TARJETA</CCLAVEASOC>
        <CCLAVE>PAG TJ</CCLAVE>
        <CTEXTO>Pago Minimo</CTEXTO>
      </VALOR>
    </VALORES>
  </CAMPO>
  <CAMPO>
    <CCLAVE>NMONTOMINIMO</CCLAVE>
    <CTIPO>TPREAL</CTIPO>
    <CNOMBRE>Monto minimo de interes</CNOMBRE>
    <LVACIO>1</LVACIO>
    <LMODIFICABLE>1</LMODIFICABLE>
    <NMINIMO>10.59</NMINIMO>
    <NMAXIMO>4000.53</NMAXIMO>
  </CAMPO>
  <CAMPO>
    <CCLAVE>NPERIODOS</CCLAVE>
    <CTIPO>TPENTERO</CTIPO>
    <CNOMBRE>Periodos a Procesar</CNOMBRE>
    <NMINIMO>1</NMINIMO>
    <NMAXIMO>1000</NMAXIMO>
    <LVACIO>1</LVACIO>
  </CAMPO>
</CDIALOGO>'
GO

USE [cgQuartz]
GO
/****** Object:  StoredProcedure [dbo].[OP_PROCESO_EJEMPLO_EXEC]    Script Date: 08/27/2012 23:43:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*

Ejemplo de uso

Declare @cParametro varchar(4000) 
Declare @xInput  xml 
Declare @xParametrosInput xml
Declare @xOutput  xml
Declare @xLogEjecucion     xml
Declare @xResultado  xml 
Declare	@nRowsAffected int
Declare	@nRowsTotal int
Declare	@cStatus varchar(100)
Declare	@nTriggerId int

Exec [OP_PROCESO_QUARTZ_EXEC]
				@nTriggerId,
				@xParametrosInput,
				@xInput  , 
				@xOutput  OUT,  -- Salida de la tabla. Respuesta al xInput
				@xResultado  OUT, -- Resultado del negocio, html valido
				@xLogEjecucion OUT, 
				@nRowsAffected  OUT, 
				@nRowsTotal OUT,
				@cStatus OUT 				

select	@xOutput  
select	@xResultado
select	@xLogEjecucion
select	@nRowsAffected
select	@nRowsTotal
select	@cStatus
select	@xParametrosInput
select	@xResultado

*/
GO              

CREATE Procedure [dbo].[OP_PROCESO_QUARTZ_EXEC] 

@nTriggerId int OUT,
@xParametrosInput xml,
@xInput  xml , -- Datos de input que limitan los registros a procesar
@xOutput  xml OUT, -- XML de salida Output
@xResultado xml OUT, -- Reporte de Salida resumenes etc.
@xLogEjecucion     xml OUT, -- Log
@nRowsAffected  int OUT, 
@nRowsTotal int OUT,
@cStatus varchar(100) OUT 

as

	Set nocount on
	
	RAISERROR ('Mensaje de Trace 1',2,1) WITH NOWAIT

	WAITFOR DELAY '00:00:35'

	RAISERROR ('Mensaje de Trace 2',2,1) WITH NOWAIT

	Declare	@nId int
	Declare	@nIdMax int

	Set	@nId 	= 1
	Set	@nIdMax = 10

--set @nId = 1/0
	
	Set @cStatus = 'Anduvo OK'

	Set	@xLogEjecucion=  convert(varchar,getdate(),111) + ' ' + convert(varchar,getdate(),108) + ' Inicia proceso<BR />'

	set	@xLogEjecucion=  (select @xLogEjecucion , cast(convert(varchar,getdate(),111) + ' ' + convert(varchar,getdate(),108) + ' Crea Tabla Temporaria<BR />' as xml)
			for xml path (''))

Create Table #OutPut
		(
		nId int,
		cCampo1 varchar(100),
		cCampo2 varchar(100),
		cCampo3 varchar(100),
		cCampo4 varchar(100),
		cCampo5 varchar(100),
		cCampo6 varchar(100),
		cCampo7 varchar(100),
		cCampo8 varchar(100),
		cCampo9 varchar(100),
		cCampo10 varchar(100),
		cEstado varchar(10),
		cComentario varchar(255)
		)

	Set	@xLogEjecucion=  (select @xLogEjecucion , cast( convert(varchar,getdate(),111) + ' ' + convert(varchar,getdate(),108) + ' Inicia LOOP<BR />' as xml)
			for xml path (''))

	While	@nId 	<= @nIdMax 
	Begin

		Insert	#OutPut
		Values
			(@nId ,
			'Campo 1 registro ' + convert(varchar,@nId),
			'Campo 2 registro ' + convert(varchar,@nId),
			'Campo 3 registro ' + convert(varchar,@nId),
			'Campo 4 registro ' + convert(varchar,@nId),
			'Campo 5 registro ' + convert(varchar,@nId),
			'Campo 6 registro ' + convert(varchar,@nId),
			'Campo 7 registro ' + convert(varchar,@nId),
			'Campo 8 registro ' + convert(varchar,@nId),
			'Campo 9 registro ' + convert(varchar,@nId),
			'Campo 10 registro ' + convert(varchar,@nId),
			'PENDIENTE',
			'Comentario ' + convert(varchar,@nId)
			)

		Set	@nId 	= @nId 	  + 1 
	End
	

	Set	@xLogEjecucion=  (select @xLogEjecucion ,  cast(convert(varchar,getdate(),111) + ' ' + convert(varchar,getdate(),108) + ' Finaliza LOOP<BR />' as xml)
			for xml path (''))


	Set	@xLogEjecucion=  (select @xLogEjecucion ,  cast(convert(varchar,getdate(),111) + ' ' + convert(varchar,getdate(),108) + ' Inicia armado de Output<BR />' as xml)
			for xml path (''))

	Set	@xOutput  = 	(   
				Select 	*
				From 	#OutPut
				For Xml raw('tr'), elements
				)

	Set	@xLogEjecucion=  (select @xLogEjecucion , cast(convert(varchar,getdate(),111) + ' ' + convert(varchar,getdate(),108) + ' Finaliza armado de Output<BR />' as xml)
			for xml path (''))


	Set	@xLogEjecucion=  (select @xLogEjecucion ,  cast(convert(varchar,getdate(),111) + ' ' + convert(varchar,getdate(),108) + ' Inicia armado de resultado resumen<BR />' as xml)
			for xml path (''))

	Set	@xResultado  = (
					select cEstado as TD, count(*) as TD
					from 	#OutPut
					group by cEstado
					For Xml raw('tr'), elements
				 )


	Set	@xLogEjecucion=  (select @xLogEjecucion ,  cast(convert(varchar,getdate(),111) + ' ' + convert(varchar,getdate(),108) + ' Finaliza armado de resultado resumen<BR />' as xml)
			for xml path (''))



	Set	@xLogEjecucion=  (select @xLogEjecucion , cast(convert(varchar,getdate(),111) + ' ' + convert(varchar,getdate(),108) + ' Finaliza proceso<BR />' as xml)
			for xml path (''))

Select	@xResultado =  '
					<style type="text/css">
							BODY        { background-color : #FFFFFF; font-family : arial; text-align : left; color : black;}
							.comercial  { BORDER : 0 solid #000; width : 100%; margin : 0; border-collapse : collapse; border-spacing : 0;}
							.fecha      { BORDER : 0 solid #000;  width : 15%; font-size : 10pt; font-family : arial; background-color : #FFFFFF; text-align : left;}
							.titulo     { BORDER : 0 solid #000; width : 70%; font-size : 10pt; font-family : arial; background-color : #FFFFFF; text-align : center;}
							.Subtitulo  { BORDER : 0 solid #000; width : 70%; font-size : 10pt; font-family : arial; background-color : #FFFFFF; text-align : center;}
							.hora       { BORDER : 0 solid #000; width : 15%; font-size : 10pt; font-family : arial; background-color : #FFFFFF; text-align : right;}							
							.Columnas   { BORDER : 0 solid #000; font-size : 12pt; font-family : arial; background-color : #FFFFFF; text-align : center; border-bottom-width:1px}
							.Columna1   { BORDER : 0 solid #000; width : 15%;  font-size : 10pt; font-family : arial; background-color : #FFFFFF; text-align : left;}							
							.Rotulo     { BORDER : 0 solid #000; font-family : arial; font-size : 10pt; text-align : left;} 
							.Datos      { BORDER : 0 solid #000;  font-size : 8pt; font-family : arial; background-color : #FFFFFF; text-align : center; width ; border-bottom-width:1px;border-bottom-style:dotted}
							.DatosPequeño { BORDER : 0 solid #000;  font-size : 8pt; font-family : arial; background-color : #FFFFFF; text-align : Left; width ; border-bottom-width:1px;border-bottom-style:dotted}
							.RotuloTotal{ BORDER : 0 solid #000; font-family : arial; font-size : 15pt;  text-align : left; border-top-width:2px;border-top-style:solid} 
							.DatosTotal { BORDER : 0 solid #000;   font-size : 8pt; font-family : arial; background-color : #FFFFFF; text-align : center; border-top-width:2px;border-top-style:solid}
					</style>
				
			<table border="1" width="100%">
				<tr>
					<td class="fecha" style="width:15%" rowspan="2">24/08/2012 18:52</td>
					<td class="titulo" style="width:15%" rowspan="2"></td>
					<td class="hora" style="width:70%"><div style ="color: #E7281F" >Todas las sucursales</div></td>
				</tr>
				<tr>
					<td colspan="3"><br/></td>
				</tr>
			</table>
			<table class="comercial">
					<tr >
						<td class="Columna1" width="50%">Fecha Hora</td>
						<td class="Columna1" width="50%">Accion</td>
						<td class="Columnas" width="10%">Registros Afectados</td>								
					</tr>
					<tr>
							<td class="Rotulo">04:05</td>
							<td class="Rotulo">Creacion Tabla Temporaria</td>
							<td class="Datos">0</td>
					</tr>
					<tr>
							<td class="Rotulo">04:07</td>
							<td class="Rotulo">Llenado de Tabla Temporaria</td>
							<td class="Datos">1501</td>
					</tr>
					<tr>
							<td class="Rotulo">04:09</td>
							<td class="Rotulo">Completado de Campos</td>
							<td class="Datos">1501</td>
					</tr>
					<tr>
							<td class="Rotulo">04:15</td>
							<td class="Rotulo">Eliminar duplicados</td>
							<td class="Datos"><font color="red">12</font></td>
					</tr>
					<tr>
							<td class="Rotulo">04:19</td>
							<td class="Rotulo">Impactar solo Telefonos</td>
							<td class="Datos">120</td>
					</tr>
					<tr>
							<td class="Rotulo">04:21</td>
							<td class="Rotulo">Fin de proceso</td>
							<td class="Datos">0</td>
					</tr>
			</table>
			'
			
Set	@nRowsAffected = 1000
Set	@nRowsTotal = 750
