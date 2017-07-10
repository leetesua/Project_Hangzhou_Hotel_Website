Use HotelDB
go
if exists  (select * from sysobjects  where name='prPager')
drop procedure prPager
go
create procedure   prPager
	@PageSize INT, ----ÿҳ��¼��
	@CurrentCount INT, ----��ǰ��¼������ҳ��*ÿҳ��¼����
	@TableName NVARCHAR(200), ----������
	@Where NVARCHAR(800), ----��ѯ����
	@Order NVARCHAR(800),----��������
	@TotalCount INT OUTPUT ----��¼����
AS
	DECLARE @sqlSelect    NVARCHAR(2000) ----�ֲ�������sql��䣩����ѯ��¼��
	DECLARE @sqlGetCount  NVARCHAR(2000) ----�ֲ�������sql��䣩��ȡ����¼������
	
	
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
