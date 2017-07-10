--插入测试数据
use HotelDB
go
--管理员信息
insert into SysAdmins(LoginId,LoginPwd,LoginName)values(1001,'123456','李浩')
insert into SysAdmins(LoginId,LoginPwd,LoginName)values(1002,'123456','赵雪伶')
--新闻分类
insert into NewsCategory(CategoryName)values('公司新闻')
insert into NewsCategory(CategoryName)values('社会新闻')
--菜品分类
insert into DishCategory(CategoryName)values('川菜')
insert into DishCategory(CategoryName)values('湘菜')
insert into DishCategory(CategoryName)values('鲁菜')
insert into DishCategory(CategoryName)values('海鲜类')
insert into DishCategory(CategoryName)values('其他')
--新闻
insert into News(NewsTitle,NewsContents,CategoryId)values('迎接十一海鲜大促销','最新鲜的鱼类全面上市，欢迎新老顾客品尝。',1)
insert into News(NewsTitle,NewsContents,CategoryId)values('本店正在热招加盟商','如果您愿意在酒店行业有所突破，请加入我们。',1)
insert into News(NewsTitle,NewsContents,CategoryId)values('互联网的消费正在兴起','网上购物已经成为人们生活必不可少的一部分。',2)
insert into News(NewsTitle,NewsContents,CategoryId)values('本店正在热招加盟商','如果您愿意在酒店行业有所突破，请加入我们。',1)
insert into News(NewsTitle,NewsContents,CategoryId)values('互联网的消费正在兴起','网上购物已经成为人们生活必不可少的一部分。',2)
--菜品信息
insert into Dishes(DishName,UnitPrice,CategoryId)values('水煮鱼',50,1)
insert into Dishes(DishName,UnitPrice,CategoryId)values('回锅肉',85,1)
insert into Dishes(DishName,UnitPrice,CategoryId)values('剁椒鱼头',75,2)
insert into Dishes(DishName,UnitPrice,CategoryId)values('红椒腊牛肉',40,2)
insert into Dishes(DishName,UnitPrice,CategoryId)values('糖醋鲤鱼',70,3)
insert into Dishes(DishName,UnitPrice,CategoryId)values('玉记扒鸡',60,3)
insert into Dishes(DishName,UnitPrice,CategoryId)values('汤爆双脆',90,3)
insert into Dishes(DishName,UnitPrice,CategoryId)values('赤贝',80,4)
--预定信息
insert into DishBook(HotelName,ConsumeTime,ConsumePersons,RoomType,CustomerName,CustomerPhone,CustomerEmail,Comments)
values('天津南开店','2014-09-11 12:30',5,'包间','李丽','13589011222','lilivip@163.com','希望房间敞亮些')
insert into DishBook(HotelName,ConsumeTime,ConsumePersons,RoomType,CustomerName,CustomerPhone,CustomerEmail,Comments)
values('天津和平店','2014-10-11 14:30',5,'包间','王鑫新','13889018888','wangxinxin@qq.com','希望房间安静些')
insert into DishBook(HotelName,ConsumeTime,ConsumePersons,RoomType,CustomerName,CustomerPhone,CustomerEmail,Comments)
values('北京朝阳点','2014-12-10 17:30',5,'散座','刘花雨','13689011999','liuhuayu@126.com','房间靠里面点儿')
--招聘信息
insert into Recruitment(PostName,PostType,PostPlace,PostDesc,PostRequire,Experience,EduBackground,RequireCount,Manager,PhoneNumber,Email)
values('大堂经理','全职','天津','负责一层楼的管理','要求具备该职位3年以上经营管理经验','3年','本科',2,'李超阳','15689011231','lichaoyang@hyl.com')
insert into Recruitment(PostName,PostType,PostPlace,PostDesc,PostRequire,Experience,EduBackground,RequireCount,Manager,PhoneNumber,Email)
values('接待员','全职','北京','负责客户的接待礼仪','要求具备该职位1年以上经验','1年','高中',5,'李超阳','15689011231','lichaoyang@hyl.com')
insert into Recruitment(PostName,PostType,PostPlace,PostDesc,PostRequire,Experience,EduBackground,RequireCount,Manager,PhoneNumber,Email)
values('总经理助理','全职','天津','负责日常的文秘工作','要求具备该职位3年以上经营管理经验','3年','本科',1,'李超阳','15689011231','lichaoyang@hyl.com')
--投诉建议
insert into Suggestion(CustomerName,ConsumeDesc,SuggestionDesc,PhoneNumber,Email)
values('杜小杰','在该店举行一次婚礼','感觉总体服务不到位，菜品味道没有以前的好。','15687423456','duxiaojie@qq.com')
insert into Suggestion(CustomerName,ConsumeDesc,SuggestionDesc,PhoneNumber,Email)
values('柳钢','在本店聚会一次','感觉上菜有点慢,希望后续改进。','15686623456','liugang@qq.com')

