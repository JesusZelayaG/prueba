drop database if exists inventory;
create database inventory;
use inventory;
/*User data*/
create table users(
	id_user int not null auto_increment,
    first_name varchar(15) not null,
    second_name varchar(15) not null,
    last_name varchar(20) not null,
    second_last_name varchar (20) not null,
    user_email varchar(150) not null,
    user_password varchar(30) not null,
    user_type varchar(25) not null,
    primary key (id_user)
);
/*Product Table*/
create table products(
	id_product varchar(45) not null,
    product_name varchar(20) not null,
    product_desc varchar(200) not null,
    product_price double not null,
    category varchar(25) not null,
    primary key (id_product)
);
