
select * from TopicInfo
select * from TestInfo
select * from TopicsInfo
select * from UserInfo
select * from TestInfo where TopicId = 1
delete from TestInfo
delete from TopicsInfo
use F3XDB
select  top 100 * from C#从入门到入土 order by newid()

update UserInfo set UserName='wuhudasima',UserGender='男',UserPhone='18182119303',UserQQ='1586689672',UserWeChat='520xkm',UserDesc='java程序员' where UserId=1

select * from TopicClass

select t.ExamId,t.ExamTabName,ty.CalssName,t.TopicCount,u.UserName,t.CreateTime from TopicsInfo t,UserInfo u,TopicClass ty
where t.Creator = u.UserId and t.ExamClass = ty.ClassId

delete from TopicsInfo
SELECT table_name FROM information_schema.TABLES WHERE table_name ='TopicsInfo'
select count(*) from sysobjects  where name='22';
select count(*) from sysobjects  where name='UserInfo'
IF OBJECT_ID('222') IS NULL SELECT 0 ELSE SELECT 1
select * from TopicInfo 
  select * from Java从入门到精通 where DATALENGTH(rig) > 2
  select * from Java从入门到精通 where DATALENGTH(rig) = 2
drop table wuhu
  update GO set IsRight = '0' 
select * from wuhu
create table wuhu(
id int)
select t.ExamId,t.ExamTabName,ty.CalssName,t.TopicCount,u.UserName,t.CreateTime from TopicsInfo t,UserInfo u,TopicClass ty
where t.Creator = u.UserId and t.ExamClass = ty.ClassId

--建表语句
create table UserInfo(
UserId int primary key identity(1,1),
UserAccount nvarchar(50) not null,
UserPwd nvarchar(50) not null,
UserPic nvarchar(50) not null,
UserPhone nvarchar(50) not null,
UserName nvarchar(50) not null,
UserGender nvarchar(2),
UserCount nvarchar(50) not null,
UserDesc nvarchar(50) ,
UserQQ nvarchar(50) ,
UserWeChat nvarchar(50) 
)
go

create table TopicClass(
ClassId int primary key identity(1,1),
CalssName nvarchar(50) not null,
)
go

create table TopicsInfo(
ExamId int primary key identity(1,1),
ExamTabName nvarchar(50) not null,
ExamClass int foreign key references TopicClass(ClassId),
TopicCount int not null,
Creator int not null foreign key references UserInfo(UserId),
CreateTime date not null,
)
go

create table TopicInfo(
TopicId int primary key identity(1,1),
TopicType nvarchar(50),
Topic nvarchar(1024),
A nvarchar(1024) not null,
B nvarchar(1024),
C nvarchar(1024),
D nvarchar(1024),
Rig nvarchar(50) not null,
TopicDesc text not null
)
go

create table TestInfo(
TestId int primary key identity(1,1),
TestName nvarchar(50) not null,
TopicId int not null foreign key references TopicsInfo(ExamId),
TestTime int not null,
TestPassScore int not null,
)
go

select * from TopicsInfo
select * from TestInfo
select * from TopicInfo

select t.ExamId,t.ExamTabName,ty.CalssName,t.TopicCount,u.UserName,t.CreateTime from TopicsInfo t,UserInfo u,TopicClass ty where t.Creator = u.UserId and t.ExamClass = ty.ClassId

select * from UserInfo 

select * from C#从入门到入土 order by newid()
select Rig from C#从入门到入土 where TopicId = 6

-- 用户表
insert into UserInfo values('12345','555','wuhu.jpg','18182119303','wuhudasima','男','88','java程序员','1586689672','520xkm')
select * from UserInfo

select t.ExamId,t.ExamTabName,ty.CalssName,t.TopicCount,u.UserName,t.CreateTime from TopicsInfo t,UserInfo u,TopicClass ty
where t.Creator = u.UserId and t.ExamClass = ty.ClassId

--试卷类型表
insert into TopicClass 
select 'C语言' union
select 'Java' union
select 'C++' union
select 'C#'  union
select 'python'


insert into TestInfo
select '1',13,50,100 union
select '1',13,50,100 union
select '1',13,50,100 union
select '1',13,50,100 union
select '1',13,50,100 union
select '1',13,50,100 union
select '1',13,50,100 union
select '1',13,50,100 union
select '1',13,50,100 union
select '1',13,50,100 union
select '1',13,50,100 union
select '1',13,50,100 union
select '1',13,50,100 union
select '1',13,50,100 union
select '1',13,50,100 


select * from TopicsInfo
select * from GO
delete from TestInfo
delete from UserInfo
delete from TopicsInfo

select t.ExamId,t.ExamTabName,ty.CalssName,t.TopicCount,u.UserName,t.CreateTime from TopicsInfo t,UserInfo u,TopicClass ty
where t.Creator = u.UserId and t.ExamClass = ty.ClassId

create table UserExamState(
Id int primary key identity(1,1),
UserId int foreign key references Userinfo(UserId),
TestId int foreign key references Testinfo(TestId),
Examstatus int not null
)

select * from UserExamState