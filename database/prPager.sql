Use HotelDB
go
if exists  (select * from sysobjects  where name='prPager')
drop procedure prPager
go
create procedure   prPager
	@PageSize INT, ----每页记录数
	@CurrentCount INT, ----当前记录数量（页码*每页记录数）
	@TableName NVARCHAR(200), ----表名称
	@Where NVARCHAR(800), ----查询条件
	@Order NVARCHAR(800),----排序条件
	@TotalCount INT OUTPUT ----记录总数
AS
	DECLARE @sqlSelect    NVARCHAR(2000) ----局部变量（sql语句），查询记录集
	DECLARE @sqlGetCount  NVARCHAR(2000) ----局部变量（sql语句），取出记录集总数
	
	
	SET @sqlSelect = 'SELECT * FROM  ' 
	    + '    (SELECT ROW_NUMBER()  OVER( ORDER BY ' + @Order +
	    ' ) AS RowNumber,* '
	    + '        FROM ' + @TableName 
	    + '        WHERE ' + @Where 
	    + '     ) as  T2 ' 
	    + ' WHERE T2.RowNumber<= ' + STR(@CurrentCount + @PageSize) +
	    ' AND T2.RowNumber>' + STR(@CurrentCount) 
	
	SET @sqlGetCount = 'SELECT @TotalCount = COUNT(*) FROM ' + @TableName 
	    + ' WHERE ' + @Where
	
	
	EXEC (@sqlSelect) 
	EXEC SP_EXECUTESQL @sqlGetCount,
	     N'@TotalCount INT OUTPUT',
	     @TotalCount OUTPUT
