 CREATE TRIGGER ActualizarStock_Venta
 ON detalle_venta
 FOR INSERT
 AS
 UPDATE a SET a.stock=a.stock - d.cantidad
 FROM articulo a INNER JOIN
 INSERTED d ON a.idarticulo =d.idarticulo