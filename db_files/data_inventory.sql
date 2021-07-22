use inventory;

/*Insert Users*/
insert into users(
	first_name,
	second_name,
    last_name,
    second_last_name,
    user_email,
    user_password,
    user_type
)
values(
	'Jesus',
    'Ernesto',
    'Zelaya',
    'Garcia',
    'jesus.zelayag@gmail.com',
    'jezg123456',
    'Administrador'
);
insert into users(
	first_name,
	second_name,
    last_name,
    second_last_name,
    user_email,
    user_password,
    user_type
)
values(
	'Sonia',
    'Concepcion',
    'Garcia',
    'Ardon',
    'sonia.cgarcia@gmail.com',
    'sg456844',
    'Bodeguero'
);
insert into users(
	first_name,
	second_name,
    last_name,
    second_last_name,
    user_email,
    user_password,
    user_type
)
values(
	'Miriam',
    'Elizabeth',
    'Caceres',
    'Zamora',
    'miriam.caceres@gmail.com',
    'sg456844',
    'Bodeguero'
);

/*Insert products*/
insert into products(
	id_product,
    product_name,
    product_desc,
    product_price,
    category
)
values(
	'n1898',
    'camisa',
    'camisa color negra casual',
    12.25,
    'ropa'
);
insert into products(
	id_product,
    product_name,
    product_desc,
    product_price,
    category
)
values(
	'g5896',
    'audifonos',
    'audifonos negros con tematica gaming',
    30.50,
    'tecnologia'
);
insert into products(
	id_product,
    product_name,
    product_desc,
    product_price,
    category
)
values(
	'l500',
    'acetaminofen',
    'medicamento para tratar fiebre y dolor leve',
    5.50,
    'medicamento'
);