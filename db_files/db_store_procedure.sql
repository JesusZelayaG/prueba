USE `inventory`;
DROP procedure IF EXISTS `insert_user`;
DROP procedure IF EXISTS `update_user`;
DROP procedure IF EXISTS `delete_user`;
DROP procedure IF EXISTS `select_user`;
DROP procedure IF EXISTS `login`;

/*Store Procedure user table*/

DELIMITER $$
USE `inventory`$$
CREATE PROCEDURE `insert_user` (
	in f_name varchar(15),
    in s_name varchar(15),
    in l_name varchar(20),
    in s_last_name varchar(20),
    in u_email varchar(150),
    in u_password varchar(30),
    in u_type varchar(25)
)
BEGIN
	insert into users(
		first_name,
		second_name,
		last_name,
		second_last_name,
		user_email,
		user_password,
		user_type
    )
    values (
		f_name,
		s_name,
		l_name,
		s_last_name,
		u_email,
		u_password,
        u_type
    );
END$$
DELIMITER ;

DELIMITER $$
USE `inventory`$$
CREATE PROCEDURE `update_user` (
	in i_user int,
	in f_name varchar(15),
    in s_name varchar(15),
    in l_name varchar(20),
    in s_last_name varchar(20),
    in u_email varchar(150),
    in u_password varchar(30),
    in u_type varchar(25)
)
BEGIN
	update users set
		first_name = f_name,
		second_name = s_name,
		last_name = l_name,
		second_last_name = s_last_name,
		user_email = u_email,
		user_password = u_password,
		user_type = u_type
    where id_user = i_user;
END$$
DELIMITER ;

DELIMITER $$
USE `inventory`$$
CREATE PROCEDURE `delete_user` (
	in i_user int
)
BEGIN
	DELETE FROM users WHERE id_user = i_user;
END$$
DELIMITER ;

DELIMITER $$
USE `inventory`$$
CREATE PROCEDURE `select_user` (
	in i_user int
)
BEGIN
	SELECT * FROM users WHERE id_user = i_user;
END$$
DELIMITER ;

/*Store procedures products*/
USE `inventory`;
DROP procedure IF EXISTS `insert_product`;
DROP procedure IF EXISTS `update_product`;
DROP procedure IF EXISTS `delete_product`;
DROP procedure IF EXISTS `select_product`;

DELIMITER $$
USE `inventory`$$
CREATE PROCEDURE `insert_product` (
	in i_product varchar(45),
    in p_name varchar(20),
    in p_desc varchar(200),
    in p_price double,
    in p_category varchar(25)
)
BEGIN
	insert into products(
		id_product,
		product_name,
		product_desc,
		product_price,
		category
    )
    values (
		i_product,
		p_name,
		p_desc,
		p_price,
		p_category
    );
END$$
DELIMITER ;

DELIMITER $$
USE `inventory`$$
CREATE PROCEDURE `update_product` (
	in i_product varchar(45),
    in p_name varchar(20),
    in p_desc varchar(200),
    in p_price double,
    in p_category varchar(25)
)
BEGIN
	update products set
		product_name= p_name,
		product_desc = p_desc,
		product_price = p_price,
		category = p_category
    where 
		id_product = i_product;
END$$
DELIMITER ;

DELIMITER $$
USE `inventory`$$
CREATE PROCEDURE `delete_product` (
	in i_product varchar(45)
)
BEGIN
	DELETE FROM products WHERE id_product = i_product;
END$$
DELIMITER ;

DELIMITER $$
USE `inventory`$$
CREATE PROCEDURE `select_product` (
	in i_product varchar(45)
)
BEGIN
	SELECT * FROM products WHERE id_product = i_product;
END$$
DELIMITER ;
DELIMITER $$
USE `inventory`$$
CREATE PROCEDURE `login` (
	in u_email varchar(45),
    in u_pass varchar(30)
)
BEGIN
	SELECT * FROM users WHERE user_email = u_email and user_password = u_pass;
END$$
DELIMITER ;

