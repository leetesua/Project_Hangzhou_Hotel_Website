--�����������
use HotelDB
go
--����Ա��Ϣ
insert into SysAdmins(LoginId,LoginPwd,LoginName)values(1001,'123456','���')
insert into SysAdmins(LoginId,LoginPwd,LoginName)values(1002,'123456','��ѩ��')
--���ŷ���
insert into NewsCategory(CategoryName)values('��˾����')
insert into NewsCategory(CategoryName)values('�������')
--��Ʒ����
insert into DishCategory(CategoryName)values('����')
insert into DishCategory(CategoryName)values('���')
insert into DishCategory(CategoryName)values('³��')
insert into DishCategory(CategoryName)values('������')
insert into DishCategory(CategoryName)values('����')
--����
insert into News(NewsTitle,NewsContents,CategoryId)values('ӭ��ʮһ���ʴ����','�����ʵ�����ȫ�����У���ӭ���Ϲ˿�Ʒ����',1)
insert into News(NewsTitle,NewsContents,CategoryId)values('�����������м�����','�����Ը���ھƵ���ҵ����ͻ�ƣ���������ǡ�',1)
insert into News(NewsTitle,NewsContents,CategoryId)values('��������������������','���Ϲ����Ѿ���Ϊ��������ز����ٵ�һ���֡�',2)
insert into News(NewsTitle,NewsContents,CategoryId)values('�����������м�����','�����Ը���ھƵ���ҵ����ͻ�ƣ���������ǡ�',1)
insert into News(NewsTitle,NewsContents,CategoryId)values('��������������������','���Ϲ����Ѿ���Ϊ��������ز����ٵ�һ���֡�',2)
--��Ʒ��Ϣ
insert into Dishes(DishName,UnitPrice,CategoryId)values('ˮ����',50,1)
insert into Dishes(DishName,UnitPrice,CategoryId)values('�ع���',85,1)
insert into Dishes(DishName,UnitPrice,CategoryId)values('�罷��ͷ',75,2)
insert into Dishes(DishName,UnitPrice,CategoryId)values('�콷��ţ��',40,2)
insert into Dishes(DishName,UnitPrice,CategoryId)values('�Ǵ�����',70,3)
insert into Dishes(DishName,UnitPrice,CategoryId)values('��ǰǼ�',60,3)
insert into Dishes(DishName,UnitPrice,CategoryId)values('����˫��',90,3)
insert into Dishes(DishName,UnitPrice,CategoryId)values('�౴',80,4)
--Ԥ����Ϣ
insert into DishBook(HotelName,ConsumeTime,ConsumePersons,RoomType,CustomerName,CustomerPhone,CustomerEmail,Comments)
values('����Ͽ���','2014-09-11 12:30',5,'����','����','13589011222','lilivip@163.com','ϣ�����䳨��Щ')
insert into DishBook(HotelName,ConsumeTime,ConsumePersons,RoomType,CustomerName,CustomerPhone,CustomerEmail,Comments)
values('����ƽ��','2014-10-11 14:30',5,'����','������','13889018888','wangxinxin@qq.com','ϣ�����䰲��Щ')
insert into DishBook(HotelName,ConsumeTime,ConsumePersons,RoomType,CustomerName,CustomerPhone,CustomerEmail,Comments)
values('����������','2014-12-10 17:30',5,'ɢ��','������','13689011999','liuhuayu@126.com','���俿������')
--��Ƹ��Ϣ
insert into Recruitment(PostName,PostType,PostPlace,PostDesc,PostRequire,Experience,EduBackground,RequireCount,Manager,PhoneNumber,Email)
values('���þ���','ȫְ','���','����һ��¥�Ĺ���','Ҫ��߱���ְλ3�����Ͼ�Ӫ������','3��','����',2,'���','15689011231','lichaoyang@hyl.com')
insert into Recruitment(PostName,PostType,PostPlace,PostDesc,PostRequire,Experience,EduBackground,RequireCount,Manager,PhoneNumber,Email)
values('�Ӵ�Ա','ȫְ','����','����ͻ��ĽӴ�����','Ҫ��߱���ְλ1�����Ͼ���','1��','����',5,'���','15689011231','lichaoyang@hyl.com')
insert into Recruitment(PostName,PostType,PostPlace,PostDesc,PostRequire,Experience,EduBackground,RequireCount,Manager,PhoneNumber,Email)
values('�ܾ�������','ȫְ','���','�����ճ������ع���','Ҫ��߱���ְλ3�����Ͼ�Ӫ������','3��','����',1,'���','15689011231','lichaoyang@hyl.com')
--Ͷ�߽���
insert into Suggestion(CustomerName,ConsumeDesc,SuggestionDesc,PhoneNumber,Email)
values('��С��','�ڸõ����һ�λ���','�о�������񲻵�λ����Ʒζ��û����ǰ�ĺá�','15687423456','duxiaojie@qq.com')
insert into Suggestion(CustomerName,ConsumeDesc,SuggestionDesc,PhoneNumber,Email)
values('����','�ڱ���ۻ�һ��','�о��ϲ��е���,ϣ�������Ľ���','15686623456','liugang@qq.com')

