create table Gamers
(
	Id serial primary key,
	Login text,
	Password text,
	Email text,
	Birthdate text,
	Phone text,
	EmailValidated bool,
	Date datetime default now()
);

create table Games
(
	Id serial primary key,
	Name text
);

create table GameKinds
(
	Id serial primary key,
	IdGames int references Games(Id),
	Kind text
);

create table UserReactions
(
	Id serial primary key,
	Reaction text
);

create table GamerGames
(
	Id serial primary key,
	IdGamers int references Gamers(Id),
	IdGameKinds int references GameKinds(id),
	NickName text,
	ProficiencyLevel float,
	Role int,
	Metadata text,
	Date datetime default now()
);

create table GameMetadatas
(
	Id serial primary key,
	Name text
);

create table GameKindMetadatas
(
	Id serial primary key,
	IdGameKinds int references GameKinds(id),
	IdGameMetadatas int references GameMetadatas(Id),
	Content text
);

create table GamersShowdowns
(
	Id serial primary key,
	IdGamers int references Gamers(Id),
	IdGameKinds int references GameKinds(id),
	Rank float,
	Metadata text,
	Date datetime default now()
);

create table GamersShowdownsComments
(
	Id serial primary key,
	IdGamersShowdownsComments int references GamersShowdownsComments(Id),
	IdGamers int references Gamers(Id),
	Comment text,
	Date datetime default now()
);

create table GamersShowdownsCommentsReactions
(
	Id serial primary key,
	IdGamersShowdownsComments int references GamersShowdownsComments(Id),
	IdGamers int references Gamers(Id),
	IdUserReactions int references UserReactions(Id),
	Date datetime default now()
);

create table MentoringGroups
(
	Id serial primary key,
	IdGamerGames int references GamerGames(Id),
	Name text,
	Date datetime default now()
);

create table Mentoring
(
	Id serial primary key,
	IdMentoringGroups int references MentoringGroups(Id),
	IdGamerGames int references GamerGames(Id),
	IdGamerGamesStudent int references GamerGames(Id)
);

create table MentoringDiscussion
(
	Id serial primary key,
	IdMentoring int references Mentoring(Id),
	IdGamerGames int references GamerGames(Id),
	PostContent text,
	Metadata text,
	Date datetime default now()
);

create table MentoringDiscussionComments
(
	Id serial primary key,
	IdMentoringDiscussion int references MentoringDiscussion(Id),
	IdMentoringDiscussionComments int references MentoringDiscussionComments(Id),
	IdGamerGames int references GamerGames(Id),
	Comment text,
	Date datetime default now()
);

create table FriendsInvitations
(
	Id serial primary key,
	IdGamers int references Gamers(Id),
	IdGamersFriend int references Gamers(Id),
	Date datetime default now()
);

create table Friends
(
	Id serial primary key,
	IdGamers int references Gamers(Id),
	IdGamersFriend int references Gamers(Id),
	Date datetime default now()
);

