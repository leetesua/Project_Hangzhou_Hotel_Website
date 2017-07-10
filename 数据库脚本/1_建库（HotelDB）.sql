use Master
go
if exists(select * from sysdatabases where name='HotelDB')
drop database HotelDB
go
create database HotelDB
on primary
(
	name='HotelDB_data',
	filename='D:\DB\HotelDB_data.mdf',
	size=5MB,
	filegrowth=2MB
)
 log on
(
	name='HotelDB_log',
	filename='D:\DB\HotelDB_log.ldf',
	size=5MB,
	filegrowth=2MB
)
go
use HotelDB
go
--管理员表
if exists(select * from sysobjects where name='SysAdmins')
drop table SysAdmins
go
create table SysAdmins --管理员表
(
	LoginId int primary key ,--登录账号
	LoginName varchar(20) not null, --登录名称
	LoginPwd varchar(20)	not null --登录密码
) 
go
--新闻分类表
if exists(select * from sysobjects where name='NewsCategory')
drop table NewsCategory
go
create table NewsCategory --新闻分类
(
	CategoryId int  identity(1,1) primary key ,
	CategoryName varchar(20) not null
)
go
--新闻表
if exists(select * from sysobjects where name='News')
drop table News
go
create table News  --新闻详细表
(
	NewsId int  identity(1000,1)  primary key , --新闻编号
	NewsTitle varchar(100) not null,--标题
	NewsContents text not null,--内容	
	PublishTime datetime default(getdate()),--发布时间
	CategoryId int references NewsCategory(CategoryId)--分类编号
)
go
--菜品分类表
if exists(select * from sysobjects where name='DishCategory')
drop table DishCategory
go
create table DishCategory --菜品分类
(
	CategoryId int  identity(1,1) primary key ,
	CategoryName varchar(20) not null
)
go
--菜品表
if exists(select * from sysobjects where name='Dishes')
drop table Dishes 
go
create table Dishes --菜品表
(
	DishId int  identity(100,1)  primary key , --菜品编号
	DishName varchar(100) not null,--菜品名称
	UnitPrice numeric(18,2) not null, --价格
	CategoryId int references DishCategory(CategoryId)--分类编号
)
go
--菜品预定表
if exists(select * from sysobjects where name='DishBook')
drop table DishBook
go
create table DishBook  --预定列表
(
	BookId int  identity(10000,1) primary key , --预定编号
	HotelName varchar(50) not null,   --分店名称
	ConsumeTime datetime not null,--消费时间
	ConsumePersons int not null,--消费人数
	RoomType varchar(20) not null,--包间类型
	CustomerName varchar(20) not null,--预定人姓名
	CustomerPhone varchar(100) not null,--联系电话
	CustomerEmail varchar(100),  --电子邮件
	Comments nvarchar(500), --备注内容
	BookTime datetime default(getdate()),--预定时间
	OrderStatus int default(0), --订单状态（0，未审核；1，审核通过，-1 ，撤销，2，消费完毕）	
)
go
--招聘信息表
if exists(select * from sysobjects where name='Recruitment')
drop table Recruitment
go
create table Recruitment --招聘信息表
(
	PostId int identity(100000,1) primary key ,
	PostName nvarchar(50) not null, --职位名称
	PostType char(4) not null,--(全职、兼职)
	PostPlace nvarchar(50) not null,--工作地点
	PostDesc text not null,--职位描述
	PostRequire text not null,--具体要求
	Experience nvarchar(100) not null,--工作经验
	EduBackground nvarchar(100) not null,--学历
	RequireCount int  not null,--招聘人数
	PublishTime datetime default(getdate()), --发布时间
	Manager varchar(20) not null,--联系人
	PhoneNumber varchar(100) not null,--电话
	Email varchar(100)  not null--电子邮件
)
go
--投诉建议表
if exists(select * from sysobjects where name='Suggestion')
drop table Suggestion
go
create table Suggestion --投诉建议表
(
	SuggestionId int identity(100000,1) primary key ,
	CustomerName nvarchar(50) not null, --客户姓名
	ConsumeDesc text not null,--消费说明
	SuggestionDesc text not null,--投诉建议内容
	SuggestTime datetime default(getdate()), --投诉时间	
	PhoneNumber varchar(100) not null,--电话
	Email varchar(100), --电子邮件
	StatusId int default(0)--投诉状态（0：未受理；1：已受理）
)
go










