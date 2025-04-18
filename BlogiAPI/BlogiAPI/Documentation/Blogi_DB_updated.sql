PGDMP  "    /                }        	   Bloggi_DB    17.2    17.0 J    y           0    0    ENCODING    ENCODING        SET client_encoding = 'UTF8';
                           false            z           0    0 
   STDSTRINGS 
   STDSTRINGS     (   SET standard_conforming_strings = 'on';
                           false            {           0    0 
   SEARCHPATH 
   SEARCHPATH     8   SELECT pg_catalog.set_config('search_path', '', false);
                           false            |           1262    18048 	   Bloggi_DB    DATABASE     m   CREATE DATABASE "Bloggi_DB" WITH TEMPLATE = template0 ENCODING = 'UTF8' LOCALE_PROVIDER = libc LOCALE = 'C';
    DROP DATABASE "Bloggi_DB";
                     postgres    false            �            1255    18143 �   create_banner_ad(character varying, character varying, character varying, timestamp with time zone, timestamp with time zone, boolean) 	   PROCEDURE       CREATE PROCEDURE public.create_banner_ad(IN p_title character varying, IN p_image_url character varying, IN p_redirect_url character varying, IN p_start_date timestamp with time zone, IN p_end_date timestamp with time zone, IN p_is_active boolean)
    LANGUAGE plpgsql
    AS $$
BEGIN
    INSERT INTO banner_ads (banner_id, title, image_url, redirect_url, start_date, end_date, is_active, created_at)
    VALUES (gen_random_uuid(), p_title, p_image_url, p_redirect_url, p_start_date, p_end_date, p_is_active, CURRENT_TIMESTAMP);
END;
$$;
 �   DROP PROCEDURE public.create_banner_ad(IN p_title character varying, IN p_image_url character varying, IN p_redirect_url character varying, IN p_start_date timestamp with time zone, IN p_end_date timestamp with time zone, IN p_is_active boolean);
       public               postgres    false            �            1255    18167 �   create_banner_ad(uuid, character varying, character varying, character varying, timestamp with time zone, timestamp with time zone, boolean) 	   PROCEDURE     )  CREATE PROCEDURE public.create_banner_ad(IN p_banner_id uuid, IN p_title character varying, IN p_image_url character varying, IN p_redirect_url character varying, IN p_start_date timestamp with time zone, IN p_end_date timestamp with time zone, IN p_is_active boolean)
    LANGUAGE plpgsql
    AS $$
BEGIN
    INSERT INTO banner_ads (banner_id, title, image_url, redirect_url, start_date, end_date, is_active, created_at)
    VALUES (p_banner_id, p_title, p_image_url, p_redirect_url, p_start_date, p_end_date, p_is_active, CURRENT_TIMESTAMP);
END;
$$;
   DROP PROCEDURE public.create_banner_ad(IN p_banner_id uuid, IN p_title character varying, IN p_image_url character varying, IN p_redirect_url character varying, IN p_start_date timestamp with time zone, IN p_end_date timestamp with time zone, IN p_is_active boolean);
       public               postgres    false            �            1255    18146 g   create_carousel_banner(character varying, character varying, text, integer, character varying, boolean) 	   PROCEDURE       CREATE PROCEDURE public.create_carousel_banner(IN p_title character varying, IN p_image_url character varying, IN p_description text, IN p_display_order integer, IN p_redirect_url character varying, IN p_is_active boolean)
    LANGUAGE plpgsql
    AS $$
BEGIN
    INSERT INTO carousel_banners (carousel_id, title, image_url, description, display_order, redirect_url, is_active, created_at)
    VALUES (gen_random_uuid(), p_title, p_image_url, p_description, p_display_order, p_redirect_url, p_is_active, CURRENT_TIMESTAMP);
END;
$$;
 �   DROP PROCEDURE public.create_carousel_banner(IN p_title character varying, IN p_image_url character varying, IN p_description text, IN p_display_order integer, IN p_redirect_url character varying, IN p_is_active boolean);
       public               postgres    false            �            1255    18168 m   create_carousel_banner(uuid, character varying, character varying, text, integer, character varying, boolean) 	   PROCEDURE     (  CREATE PROCEDURE public.create_carousel_banner(IN p_carousel_id uuid, IN p_title character varying, IN p_image_url character varying, IN p_description text, IN p_display_order integer, IN p_redirect_url character varying, IN p_is_active boolean)
    LANGUAGE plpgsql
    AS $$
BEGIN
    INSERT INTO carousel_banners (carousel_id, title, image_url, description, display_order, redirect_url, is_active, created_at)
    VALUES (p_carousel_id, p_title, p_image_url, p_description, p_display_order, p_redirect_url, p_is_active, CURRENT_TIMESTAMP);
END;
$$;
 �   DROP PROCEDURE public.create_carousel_banner(IN p_carousel_id uuid, IN p_title character varying, IN p_image_url character varying, IN p_description text, IN p_display_order integer, IN p_redirect_url character varying, IN p_is_active boolean);
       public               postgres    false            �            1255    18137 (   create_category(character varying, text) 	   PROCEDURE       CREATE PROCEDURE public.create_category(IN p_name character varying, IN p_description text)
    LANGUAGE plpgsql
    AS $$
BEGIN
    INSERT INTO categories (category_id, name, description, created_at)
    VALUES (gen_random_uuid(), p_name, p_description, CURRENT_TIMESTAMP);
END;
$$;
 [   DROP PROCEDURE public.create_category(IN p_name character varying, IN p_description text);
       public               postgres    false            �            1255    18165 .   create_category(uuid, character varying, text) 	   PROCEDURE     /  CREATE PROCEDURE public.create_category(IN p_category_id uuid, IN p_name character varying, IN p_description text)
    LANGUAGE plpgsql
    AS $$
BEGIN
    INSERT INTO categories (category_id, name, description, created_at)
    VALUES (p_category_id, p_name, p_description, CURRENT_TIMESTAMP);
END;
$$;
 r   DROP PROCEDURE public.create_category(IN p_category_id uuid, IN p_name character varying, IN p_description text);
       public               postgres    false            �            1255    18140 L   create_post(character varying, text, character varying, uuid, uuid, boolean) 	   PROCEDURE     �  CREATE PROCEDURE public.create_post(IN p_title character varying, IN p_content text, IN p_image_url character varying, IN p_category_id uuid, IN p_author_id uuid, IN p_is_published boolean)
    LANGUAGE plpgsql
    AS $$
BEGIN
    INSERT INTO posts (post_id, title, content, image_url, category_id, author_id, created_at, updated_at, is_published)
    VALUES (gen_random_uuid(), p_title, p_content, p_image_url, p_category_id, p_author_id, CURRENT_TIMESTAMP, CURRENT_TIMESTAMP, p_is_published);
END;
$$;
 �   DROP PROCEDURE public.create_post(IN p_title character varying, IN p_content text, IN p_image_url character varying, IN p_category_id uuid, IN p_author_id uuid, IN p_is_published boolean);
       public               postgres    false            �            1255    18166 R   create_post(uuid, character varying, text, character varying, uuid, uuid, boolean) 	   PROCEDURE       CREATE PROCEDURE public.create_post(IN p_post_id uuid, IN p_title character varying, IN p_content text, IN p_image_url character varying, IN p_category_id uuid, IN p_author_id uuid, IN p_is_published boolean)
    LANGUAGE plpgsql
    AS $$
BEGIN
    INSERT INTO posts (post_id, title, content, image_url, category_id, author_id, created_at, updated_at, is_published)
    VALUES (p_post_id, p_title, p_content, p_image_url, p_category_id, p_author_id, CURRENT_TIMESTAMP, CURRENT_TIMESTAMP, p_is_published);
END;
$$;
 �   DROP PROCEDURE public.create_post(IN p_post_id uuid, IN p_title character varying, IN p_content text, IN p_image_url character varying, IN p_category_id uuid, IN p_author_id uuid, IN p_is_published boolean);
       public               postgres    false            �            1255    18131    create_role(character varying) 	   PROCEDURE     �   CREATE PROCEDURE public.create_role(IN p_name character varying)
    LANGUAGE plpgsql
    AS $$
BEGIN
    INSERT INTO roles (role_id, name, created_at)
    VALUES (gen_random_uuid(), p_name, CURRENT_TIMESTAMP);
END;
$$;
 @   DROP PROCEDURE public.create_role(IN p_name character varying);
       public               postgres    false            �            1255    18163 $   create_role(uuid, character varying) 	   PROCEDURE     �   CREATE PROCEDURE public.create_role(IN p_role_id uuid, IN p_name character varying)
    LANGUAGE plpgsql
    AS $$
BEGIN
    INSERT INTO roles (role_id, name, created_at)
    VALUES (p_role_id, p_name, CURRENT_TIMESTAMP);
END;
$$;
 S   DROP PROCEDURE public.create_role(IN p_role_id uuid, IN p_name character varying);
       public               postgres    false            �            1255    18134 c   create_user(character varying, character varying, character varying, character varying, text, uuid) 	   PROCEDURE       CREATE PROCEDURE public.create_user(IN p_firstname character varying, IN p_lastname character varying, IN p_email character varying, IN p_password_hash character varying, IN p_address text, IN p_role_id uuid)
    LANGUAGE plpgsql
    AS $$
BEGIN
    INSERT INTO users (user_id, firstname, lastname, email, password_hash, address, role_id, created_at, updated_at)
    VALUES (gen_random_uuid(), p_firstname, p_lastname, p_email, p_password_hash, p_address, p_role_id, CURRENT_TIMESTAMP, CURRENT_TIMESTAMP);
END;
$$;
 �   DROP PROCEDURE public.create_user(IN p_firstname character varying, IN p_lastname character varying, IN p_email character varying, IN p_password_hash character varying, IN p_address text, IN p_role_id uuid);
       public               postgres    false            �            1255    18164 i   create_user(uuid, character varying, character varying, character varying, character varying, text, uuid) 	   PROCEDURE       CREATE PROCEDURE public.create_user(IN p_user_id uuid, IN p_firstname character varying, IN p_lastname character varying, IN p_email character varying, IN p_password_hash character varying, IN p_address text, IN p_role_id uuid)
    LANGUAGE plpgsql
    AS $$
BEGIN
    INSERT INTO users (user_id, firstname, lastname, email, password_hash, address, role_id, created_at, updated_at)
    VALUES (p_user_id, p_firstname, p_lastname, p_email, p_password_hash, p_address, p_role_id, CURRENT_TIMESTAMP, CURRENT_TIMESTAMP);
END;
$$;
 �   DROP PROCEDURE public.create_user(IN p_user_id uuid, IN p_firstname character varying, IN p_lastname character varying, IN p_email character varying, IN p_password_hash character varying, IN p_address text, IN p_role_id uuid);
       public               postgres    false            �            1255    18145    delete_banner_ad(uuid) 	   PROCEDURE       CREATE PROCEDURE public.delete_banner_ad(IN p_banner_id uuid)
    LANGUAGE plpgsql
    AS $$
BEGIN
    DELETE FROM banner_ads
    WHERE banner_id = p_banner_id;
    
    IF NOT FOUND THEN
        RAISE EXCEPTION 'Banner ad with ID % not found', p_banner_id;
    END IF;
END;
$$;
 =   DROP PROCEDURE public.delete_banner_ad(IN p_banner_id uuid);
       public               postgres    false                       1255    18148    delete_carousel_banner(uuid) 	   PROCEDURE     1  CREATE PROCEDURE public.delete_carousel_banner(IN p_carousel_id uuid)
    LANGUAGE plpgsql
    AS $$
BEGIN
    DELETE FROM carousel_banners
    WHERE carousel_id = p_carousel_id;
    
    IF NOT FOUND THEN
        RAISE EXCEPTION 'Carousel banner with ID % not found', p_carousel_id;
    END IF;
END;
$$;
 E   DROP PROCEDURE public.delete_carousel_banner(IN p_carousel_id uuid);
       public               postgres    false            �            1255    18139    delete_category(uuid) 	   PROCEDURE       CREATE PROCEDURE public.delete_category(IN p_category_id uuid)
    LANGUAGE plpgsql
    AS $$
BEGIN
    DELETE FROM categories
    WHERE category_id = p_category_id;
    
    IF NOT FOUND THEN
        RAISE EXCEPTION 'Category with ID % not found', p_category_id;
    END IF;
END;
$$;
 >   DROP PROCEDURE public.delete_category(IN p_category_id uuid);
       public               postgres    false            �            1255    18142    delete_post(uuid) 	   PROCEDURE        CREATE PROCEDURE public.delete_post(IN p_post_id uuid)
    LANGUAGE plpgsql
    AS $$
BEGIN
    DELETE FROM posts
    WHERE post_id = p_post_id;
    
    IF NOT FOUND THEN
        RAISE EXCEPTION 'Post with ID % not found', p_post_id;
    END IF;
END;
$$;
 6   DROP PROCEDURE public.delete_post(IN p_post_id uuid);
       public               postgres    false            �            1255    18133    delete_role(uuid) 	   PROCEDURE        CREATE PROCEDURE public.delete_role(IN p_role_id uuid)
    LANGUAGE plpgsql
    AS $$
BEGIN
    DELETE FROM roles
    WHERE role_id = p_role_id;
    
    IF NOT FOUND THEN
        RAISE EXCEPTION 'Role with ID % not found', p_role_id;
    END IF;
END;
$$;
 6   DROP PROCEDURE public.delete_role(IN p_role_id uuid);
       public               postgres    false            �            1255    18136    delete_user(uuid) 	   PROCEDURE        CREATE PROCEDURE public.delete_user(IN p_user_id uuid)
    LANGUAGE plpgsql
    AS $$
BEGIN
    DELETE FROM users
    WHERE user_id = p_user_id;
    
    IF NOT FOUND THEN
        RAISE EXCEPTION 'User with ID % not found', p_user_id;
    END IF;
END;
$$;
 6   DROP PROCEDURE public.delete_user(IN p_user_id uuid);
       public               postgres    false                       1255    18160    get_all_banner_ads()    FUNCTION       CREATE FUNCTION public.get_all_banner_ads() RETURNS TABLE(banner_id uuid, title character varying, image_url character varying, redirect_url character varying, start_date timestamp with time zone, end_date timestamp with time zone, is_active boolean, created_at timestamp with time zone)
    LANGUAGE plpgsql
    AS $$
BEGIN
    RETURN QUERY
    SELECT b.banner_id, b.title, b.image_url, b.redirect_url, b.start_date, b.end_date, b.is_active, b.created_at
    FROM banner_ads b
    ORDER BY b.created_at;
END;
$$;
 +   DROP FUNCTION public.get_all_banner_ads();
       public               postgres    false                       1255    18162    get_all_carousel_banners()    FUNCTION       CREATE FUNCTION public.get_all_carousel_banners() RETURNS TABLE(carousel_id uuid, title character varying, image_url character varying, description text, display_order integer, redirect_url character varying, is_active boolean, created_at timestamp with time zone)
    LANGUAGE plpgsql
    AS $$
BEGIN
    RETURN QUERY
    SELECT cb.carousel_id, cb.title, cb.image_url, cb.description, cb.display_order, cb.redirect_url, cb.is_active, cb.created_at
    FROM carousel_banners cb
    ORDER BY cb.created_at;
END;
$$;
 1   DROP FUNCTION public.get_all_carousel_banners();
       public               postgres    false                       1255    18155    get_all_categories()    FUNCTION     I  CREATE FUNCTION public.get_all_categories() RETURNS TABLE(category_id uuid, name character varying, description text, created_at timestamp with time zone)
    LANGUAGE plpgsql
    AS $$
BEGIN
    RETURN QUERY
    SELECT c.category_id, c.name, c.description, c.created_at
    FROM categories c
    ORDER BY c.created_at;
END;
$$;
 +   DROP FUNCTION public.get_all_categories();
       public               postgres    false                       1255    18157    get_all_posts()    FUNCTION     �  CREATE FUNCTION public.get_all_posts() RETURNS TABLE(post_id uuid, title character varying, content text, image_url character varying, category_id uuid, author_id uuid, created_at timestamp with time zone, updated_at timestamp with time zone, is_published boolean)
    LANGUAGE plpgsql
    AS $$
BEGIN
    RETURN QUERY
    SELECT p.post_id, p.title, p.content, p.image_url, p.category_id, p.author_id, p.created_at, p.updated_at, p.is_published
    FROM posts p
    ORDER BY p.created_at;
END;
$$;
 &   DROP FUNCTION public.get_all_posts();
       public               postgres    false                       1255    18150    get_all_roles()    FUNCTION       CREATE FUNCTION public.get_all_roles() RETURNS TABLE(role_id uuid, name character varying, created_at timestamp with time zone)
    LANGUAGE plpgsql
    AS $$
BEGIN
    RETURN QUERY
    SELECT r.role_id, r.name, r.created_at
    FROM roles r
    ORDER BY r.created_at;
END;
$$;
 &   DROP FUNCTION public.get_all_roles();
       public               postgres    false                       1255    18152    get_all_users()    FUNCTION       CREATE FUNCTION public.get_all_users() RETURNS TABLE(user_id uuid, firstname character varying, lastname character varying, email character varying, password_hash character varying, address text, role_id uuid, created_at timestamp with time zone, updated_at timestamp with time zone)
    LANGUAGE plpgsql
    AS $$
BEGIN
    RETURN QUERY
    SELECT u.user_id, u.firstname, u.lastname, u.email, u.password_hash, u.address, u.role_id, u.created_at, u.updated_at
    FROM users u
    ORDER BY u.created_at;
END;
$$;
 &   DROP FUNCTION public.get_all_users();
       public               postgres    false                       1255    18159    get_banner_ad_by_id(uuid)    FUNCTION     �  CREATE FUNCTION public.get_banner_ad_by_id(p_banner_id uuid) RETURNS TABLE(banner_id uuid, title character varying, image_url character varying, redirect_url character varying, start_date timestamp with time zone, end_date timestamp with time zone, is_active boolean, created_at timestamp with time zone)
    LANGUAGE plpgsql
    AS $$
BEGIN
    RETURN QUERY
    SELECT b.banner_id, b.title, b.image_url, b.redirect_url, b.start_date, b.end_date, b.is_active, b.created_at
    FROM banner_ads b
    WHERE b.banner_id = p_banner_id;
    
    IF NOT FOUND THEN
        RAISE EXCEPTION 'Banner ad with ID % not found', p_banner_id;
    END IF;
END;
$$;
 <   DROP FUNCTION public.get_banner_ad_by_id(p_banner_id uuid);
       public               postgres    false                       1255    18161    get_carousel_banner_by_id(uuid)    FUNCTION     �  CREATE FUNCTION public.get_carousel_banner_by_id(p_carousel_id uuid) RETURNS TABLE(carousel_id uuid, title character varying, image_url character varying, description text, display_order integer, redirect_url character varying, is_active boolean, created_at timestamp with time zone)
    LANGUAGE plpgsql
    AS $$
BEGIN
    RETURN QUERY
    SELECT cb.carousel_id, cb.title, cb.image_url, cb.description, cb.display_order, cb.redirect_url, cb.is_active, cb.created_at
    FROM carousel_banners cb
    WHERE cb.carousel_id = p_carousel_id;
    
    IF NOT FOUND THEN
        RAISE EXCEPTION 'Carousel banner with ID % not found', p_carousel_id;
    END IF;
END;
$$;
 D   DROP FUNCTION public.get_carousel_banner_by_id(p_carousel_id uuid);
       public               postgres    false            
           1255    18154    get_category_by_id(uuid)    FUNCTION     �  CREATE FUNCTION public.get_category_by_id(p_category_id uuid) RETURNS TABLE(category_id uuid, name character varying, description text, created_at timestamp with time zone)
    LANGUAGE plpgsql
    AS $$
BEGIN
    RETURN QUERY
    SELECT c.category_id, c.name, c.description, c.created_at
    FROM categories c
    WHERE c.category_id = p_category_id;
    
    IF NOT FOUND THEN
        RAISE EXCEPTION 'Category with ID % not found', p_category_id;
    END IF;
END;
$$;
 =   DROP FUNCTION public.get_category_by_id(p_category_id uuid);
       public               postgres    false                       1255    18156    get_post_by_id(uuid)    FUNCTION     m  CREATE FUNCTION public.get_post_by_id(p_post_id uuid) RETURNS TABLE(post_id uuid, title character varying, content text, image_url character varying, category_id uuid, author_id uuid, created_at timestamp with time zone, updated_at timestamp with time zone, is_published boolean)
    LANGUAGE plpgsql
    AS $$
BEGIN
    RETURN QUERY
    SELECT p.post_id, p.title, p.content, p.image_url, p.category_id, p.author_id, p.created_at, p.updated_at, p.is_published
    FROM posts p
    WHERE p.post_id = p_post_id;
    
    IF NOT FOUND THEN
        RAISE EXCEPTION 'Post with ID % not found', p_post_id;
    END IF;
END;
$$;
 5   DROP FUNCTION public.get_post_by_id(p_post_id uuid);
       public               postgres    false                       1255    18158    get_posts_by_category_id(uuid)    FUNCTION     7  CREATE FUNCTION public.get_posts_by_category_id(p_category_id uuid) RETURNS TABLE(post_id uuid, title character varying, content text, image_url character varying, category_id uuid, author_id uuid, created_at timestamp with time zone, updated_at timestamp with time zone, is_published boolean)
    LANGUAGE plpgsql
    AS $$
BEGIN
    RETURN QUERY
    SELECT p.post_id, p.title, p.content, p.image_url, p.category_id, p.author_id, p.created_at, p.updated_at, p.is_published
    FROM posts p
    WHERE p.category_id = p_category_id
    ORDER BY p.created_at;
END;
$$;
 C   DROP FUNCTION public.get_posts_by_category_id(p_category_id uuid);
       public               postgres    false                       1255    18149    get_role_by_id(uuid)    FUNCTION     �  CREATE FUNCTION public.get_role_by_id(p_role_id uuid) RETURNS TABLE(role_id uuid, name character varying, created_at timestamp with time zone)
    LANGUAGE plpgsql
    AS $$
BEGIN
    RETURN QUERY
    SELECT r.role_id, r.name, r.created_at
    FROM roles r
    WHERE r.role_id = p_role_id;
    
    IF NOT FOUND THEN
        RAISE EXCEPTION 'Role with ID % not found', p_role_id;
    END IF;
END;
$$;
 5   DROP FUNCTION public.get_role_by_id(p_role_id uuid);
       public               postgres    false                       1255    18169 #   get_role_by_name(character varying)    FUNCTION     �  CREATE FUNCTION public.get_role_by_name(p_name character varying) RETURNS TABLE(role_id uuid, name character varying, created_at timestamp with time zone)
    LANGUAGE plpgsql
    AS $$
BEGIN
    RETURN QUERY
    SELECT r.role_id, r.name, r.created_at
    FROM roles r
    WHERE r.name = p_name;
    
    IF NOT FOUND THEN
        RAISE EXCEPTION 'Role with name % not found', p_name;
    END IF;
END;
$$;
 A   DROP FUNCTION public.get_role_by_name(p_name character varying);
       public               postgres    false                       1255    18170 $   get_user_by_email(character varying)    FUNCTION     �  CREATE FUNCTION public.get_user_by_email(p_email character varying) RETURNS TABLE(user_id uuid, firstname character varying, lastname character varying, email character varying, password_hash character varying, address text, role_id uuid, created_at timestamp with time zone, updated_at timestamp with time zone)
    LANGUAGE plpgsql
    AS $$
BEGIN
    RETURN QUERY
    SELECT u.user_id, u.firstname, u.lastname, u.email, u.password_hash, u.address, u.role_id, u.created_at, u.updated_at
    FROM users u
    WHERE u.email = p_email;
    
    IF NOT FOUND THEN
        RAISE EXCEPTION 'User with email % not found', p_email;
    END IF;
END;
$$;
 C   DROP FUNCTION public.get_user_by_email(p_email character varying);
       public               postgres    false            	           1255    18171 .   get_user_by_email_with_role(character varying)    FUNCTION     �  CREATE FUNCTION public.get_user_by_email_with_role(p_email character varying) RETURNS TABLE(user_id uuid, firstname character varying, lastname character varying, email character varying, password_hash character varying, address text, role_id uuid, role_name character varying, created_at timestamp with time zone, updated_at timestamp with time zone)
    LANGUAGE plpgsql
    AS $$
BEGIN
    RETURN QUERY
    SELECT u.user_id, u.firstname, u.lastname, u.email, u.password_hash, u.address, u.role_id, r.name AS role_name, u.created_at, u.updated_at
    FROM users u
    INNER JOIN roles r ON u.role_id = r.role_id
    WHERE u.email = p_email;
    
    IF NOT FOUND THEN
        RAISE EXCEPTION 'User with email % not found', p_email;
    END IF;
END;
$$;
 M   DROP FUNCTION public.get_user_by_email_with_role(p_email character varying);
       public               postgres    false                       1255    18151    get_user_by_id(uuid)    FUNCTION     |  CREATE FUNCTION public.get_user_by_id(p_user_id uuid) RETURNS TABLE(user_id uuid, firstname character varying, lastname character varying, email character varying, password_hash character varying, address text, role_id uuid, created_at timestamp with time zone, updated_at timestamp with time zone)
    LANGUAGE plpgsql
    AS $$
BEGIN
    RETURN QUERY
    SELECT u.user_id, u.firstname, u.lastname, u.email, u.password_hash, u.address, u.role_id, u.created_at, u.updated_at
    FROM users u
    WHERE u.user_id = p_user_id;
    
    IF NOT FOUND THEN
        RAISE EXCEPTION 'User with ID % not found', p_user_id;
    END IF;
END;
$$;
 5   DROP FUNCTION public.get_user_by_id(p_user_id uuid);
       public               postgres    false                       1255    18153    get_users_by_role_id(uuid)    FUNCTION     6  CREATE FUNCTION public.get_users_by_role_id(p_role_id uuid) RETURNS TABLE(user_id uuid, firstname character varying, lastname character varying, email character varying, password_hash character varying, address text, role_id uuid, created_at timestamp with time zone, updated_at timestamp with time zone)
    LANGUAGE plpgsql
    AS $$
BEGIN
    RETURN QUERY
    SELECT u.user_id, u.firstname, u.lastname, u.email, u.password_hash, u.address, u.role_id, u.created_at, u.updated_at
    FROM users u
    WHERE u.role_id = p_role_id
    ORDER BY u.created_at;
END;
$$;
 ;   DROP FUNCTION public.get_users_by_role_id(p_role_id uuid);
       public               postgres    false            �            1255    18144 �   update_banner_ad(uuid, character varying, character varying, character varying, timestamp with time zone, timestamp with time zone, boolean) 	   PROCEDURE     %  CREATE PROCEDURE public.update_banner_ad(IN p_banner_id uuid, IN p_title character varying, IN p_image_url character varying, IN p_redirect_url character varying, IN p_start_date timestamp with time zone, IN p_end_date timestamp with time zone, IN p_is_active boolean)
    LANGUAGE plpgsql
    AS $$
BEGIN
    UPDATE banner_ads
    SET title = p_title,
        image_url = p_image_url,
        redirect_url = p_redirect_url,
        start_date = p_start_date,
        end_date = p_end_date,
        is_active = p_is_active,
        created_at = CURRENT_TIMESTAMP  -- Note: This updates the timestamp; adjust if you want to preserve original created_at
    WHERE banner_id = p_banner_id;
    
    IF NOT FOUND THEN
        RAISE EXCEPTION 'Banner ad with ID % not found', p_banner_id;
    END IF;
END;
$$;
   DROP PROCEDURE public.update_banner_ad(IN p_banner_id uuid, IN p_title character varying, IN p_image_url character varying, IN p_redirect_url character varying, IN p_start_date timestamp with time zone, IN p_end_date timestamp with time zone, IN p_is_active boolean);
       public               postgres    false                        1255    18147 m   update_carousel_banner(uuid, character varying, character varying, text, integer, character varying, boolean) 	   PROCEDURE     ,  CREATE PROCEDURE public.update_carousel_banner(IN p_carousel_id uuid, IN p_title character varying, IN p_image_url character varying, IN p_description text, IN p_display_order integer, IN p_redirect_url character varying, IN p_is_active boolean)
    LANGUAGE plpgsql
    AS $$
BEGIN
    UPDATE carousel_banners
    SET title = p_title,
        image_url = p_image_url,
        description = p_description,
        display_order = p_display_order,
        redirect_url = p_redirect_url,
        is_active = p_is_active,
        created_at = CURRENT_TIMESTAMP  -- Note: This updates the timestamp; adjust if you want to preserve original created_at
    WHERE carousel_id = p_carousel_id;
    
    IF NOT FOUND THEN
        RAISE EXCEPTION 'Carousel banner with ID % not found', p_carousel_id;
    END IF;
END;
$$;
 �   DROP PROCEDURE public.update_carousel_banner(IN p_carousel_id uuid, IN p_title character varying, IN p_image_url character varying, IN p_description text, IN p_display_order integer, IN p_redirect_url character varying, IN p_is_active boolean);
       public               postgres    false            �            1255    18138 .   update_category(uuid, character varying, text) 	   PROCEDURE       CREATE PROCEDURE public.update_category(IN p_category_id uuid, IN p_name character varying, IN p_description text)
    LANGUAGE plpgsql
    AS $$
BEGIN
    UPDATE categories
    SET name = p_name,
        description = p_description,
        created_at = CURRENT_TIMESTAMP  -- Note: This updates the timestamp; adjust if you want to preserve original created_at
    WHERE category_id = p_category_id;
    
    IF NOT FOUND THEN
        RAISE EXCEPTION 'Category with ID % not found', p_category_id;
    END IF;
END;
$$;
 r   DROP PROCEDURE public.update_category(IN p_category_id uuid, IN p_name character varying, IN p_description text);
       public               postgres    false            �            1255    18141 L   update_post(uuid, character varying, text, character varying, uuid, boolean) 	   PROCEDURE     J  CREATE PROCEDURE public.update_post(IN p_post_id uuid, IN p_title character varying, IN p_content text, IN p_image_url character varying, IN p_category_id uuid, IN p_is_published boolean)
    LANGUAGE plpgsql
    AS $$
BEGIN
    UPDATE posts
    SET title = p_title,
        content = p_content,
        image_url = p_image_url,
        category_id = p_category_id,
        is_published = p_is_published,
        updated_at = CURRENT_TIMESTAMP
    WHERE post_id = p_post_id;
    
    IF NOT FOUND THEN
        RAISE EXCEPTION 'Post with ID % not found', p_post_id;
    END IF;
END;
$$;
 �   DROP PROCEDURE public.update_post(IN p_post_id uuid, IN p_title character varying, IN p_content text, IN p_image_url character varying, IN p_category_id uuid, IN p_is_published boolean);
       public               postgres    false            �            1255    18132 $   update_role(uuid, character varying) 	   PROCEDURE     �  CREATE PROCEDURE public.update_role(IN p_role_id uuid, IN p_name character varying)
    LANGUAGE plpgsql
    AS $$
BEGIN
    UPDATE roles
    SET name = p_name,
        created_at = CURRENT_TIMESTAMP  -- Note: This updates the timestamp; adjust if you want to preserve original created_at
    WHERE role_id = p_role_id;
    
    IF NOT FOUND THEN
        RAISE EXCEPTION 'Role with ID % not found', p_role_id;
    END IF;
END;
$$;
 S   DROP PROCEDURE public.update_role(IN p_role_id uuid, IN p_name character varying);
       public               postgres    false            �            1255    18135 P   update_user(uuid, character varying, character varying, character varying, text) 	   PROCEDURE       CREATE PROCEDURE public.update_user(IN p_user_id uuid, IN p_firstname character varying, IN p_lastname character varying, IN p_email character varying, IN p_address text)
    LANGUAGE plpgsql
    AS $$
BEGIN
    UPDATE users
    SET firstname = p_firstname,
        lastname = p_lastname,
        email = p_email,
        address = p_address,
        updated_at = CURRENT_TIMESTAMP
    WHERE user_id = p_user_id;
    
    IF NOT FOUND THEN
        RAISE EXCEPTION 'User with ID % not found', p_user_id;
    END IF;
END;
$$;
 �   DROP PROCEDURE public.update_user(IN p_user_id uuid, IN p_firstname character varying, IN p_lastname character varying, IN p_email character varying, IN p_address text);
       public               postgres    false            �            1259    18103 
   banner_ads    TABLE     �  CREATE TABLE public.banner_ads (
    banner_id uuid DEFAULT gen_random_uuid() NOT NULL,
    title character varying(100) NOT NULL,
    image_url character varying(255) NOT NULL,
    redirect_url character varying(255) NOT NULL,
    start_date timestamp with time zone NOT NULL,
    end_date timestamp with time zone NOT NULL,
    is_active boolean DEFAULT true,
    created_at timestamp with time zone DEFAULT CURRENT_TIMESTAMP,
    CONSTRAINT check_date_range CHECK ((start_date <= end_date))
);
    DROP TABLE public.banner_ads;
       public         heap r       postgres    false            �            1259    18114    carousel_banners    TABLE     �  CREATE TABLE public.carousel_banners (
    carousel_id uuid DEFAULT gen_random_uuid() NOT NULL,
    title character varying(100) NOT NULL,
    image_url character varying(255) NOT NULL,
    description text,
    display_order integer NOT NULL,
    redirect_url character varying(255) NOT NULL,
    is_active boolean DEFAULT true,
    created_at timestamp with time zone DEFAULT CURRENT_TIMESTAMP
);
 $   DROP TABLE public.carousel_banners;
       public         heap r       postgres    false            �            1259    18073 
   categories    TABLE     �   CREATE TABLE public.categories (
    category_id uuid DEFAULT gen_random_uuid() NOT NULL,
    name character varying(100) NOT NULL,
    description text,
    created_at timestamp with time zone DEFAULT CURRENT_TIMESTAMP
);
    DROP TABLE public.categories;
       public         heap r       postgres    false            �            1259    18082    posts    TABLE     �  CREATE TABLE public.posts (
    post_id uuid DEFAULT gen_random_uuid() NOT NULL,
    title character varying(255) NOT NULL,
    content text NOT NULL,
    image_url character varying(255) NOT NULL,
    category_id uuid NOT NULL,
    author_id uuid NOT NULL,
    created_at timestamp with time zone DEFAULT CURRENT_TIMESTAMP,
    updated_at timestamp with time zone DEFAULT CURRENT_TIMESTAMP,
    is_published boolean DEFAULT false
);
    DROP TABLE public.posts;
       public         heap r       postgres    false            �            1259    18049    roles    TABLE     �   CREATE TABLE public.roles (
    role_id uuid DEFAULT gen_random_uuid() NOT NULL,
    name character varying(50) NOT NULL,
    created_at timestamp with time zone DEFAULT CURRENT_TIMESTAMP
);
    DROP TABLE public.roles;
       public         heap r       postgres    false            �            1259    18056    users    TABLE     �  CREATE TABLE public.users (
    user_id uuid DEFAULT gen_random_uuid() NOT NULL,
    firstname character varying(50) NOT NULL,
    lastname character varying(50) NOT NULL,
    email character varying(255) NOT NULL,
    password_hash character varying(255) NOT NULL,
    address text,
    role_id uuid NOT NULL,
    created_at timestamp with time zone DEFAULT CURRENT_TIMESTAMP,
    updated_at timestamp with time zone DEFAULT CURRENT_TIMESTAMP
);
    DROP TABLE public.users;
       public         heap r       postgres    false            u          0    18103 
   banner_ads 
   TABLE DATA           |   COPY public.banner_ads (banner_id, title, image_url, redirect_url, start_date, end_date, is_active, created_at) FROM stdin;
    public               postgres    false    221   ��       v          0    18114    carousel_banners 
   TABLE DATA           �   COPY public.carousel_banners (carousel_id, title, image_url, description, display_order, redirect_url, is_active, created_at) FROM stdin;
    public               postgres    false    222   ��       s          0    18073 
   categories 
   TABLE DATA           P   COPY public.categories (category_id, name, description, created_at) FROM stdin;
    public               postgres    false    219   �       t          0    18082    posts 
   TABLE DATA           �   COPY public.posts (post_id, title, content, image_url, category_id, author_id, created_at, updated_at, is_published) FROM stdin;
    public               postgres    false    220   �       q          0    18049    roles 
   TABLE DATA           :   COPY public.roles (role_id, name, created_at) FROM stdin;
    public               postgres    false    217   ��       r          0    18056    users 
   TABLE DATA           }   COPY public.users (user_id, firstname, lastname, email, password_hash, address, role_id, created_at, updated_at) FROM stdin;
    public               postgres    false    218   a�       �           2606    18113    banner_ads banner_ads_pkey 
   CONSTRAINT     _   ALTER TABLE ONLY public.banner_ads
    ADD CONSTRAINT banner_ads_pkey PRIMARY KEY (banner_id);
 D   ALTER TABLE ONLY public.banner_ads DROP CONSTRAINT banner_ads_pkey;
       public                 postgres    false    221            �           2606    18123 &   carousel_banners carousel_banners_pkey 
   CONSTRAINT     m   ALTER TABLE ONLY public.carousel_banners
    ADD CONSTRAINT carousel_banners_pkey PRIMARY KEY (carousel_id);
 P   ALTER TABLE ONLY public.carousel_banners DROP CONSTRAINT carousel_banners_pkey;
       public                 postgres    false    222            �           2606    18081    categories categories_pkey 
   CONSTRAINT     a   ALTER TABLE ONLY public.categories
    ADD CONSTRAINT categories_pkey PRIMARY KEY (category_id);
 D   ALTER TABLE ONLY public.categories DROP CONSTRAINT categories_pkey;
       public                 postgres    false    219            �           2606    18092    posts posts_pkey 
   CONSTRAINT     S   ALTER TABLE ONLY public.posts
    ADD CONSTRAINT posts_pkey PRIMARY KEY (post_id);
 :   ALTER TABLE ONLY public.posts DROP CONSTRAINT posts_pkey;
       public                 postgres    false    220            �           2606    18055    roles roles_pkey 
   CONSTRAINT     S   ALTER TABLE ONLY public.roles
    ADD CONSTRAINT roles_pkey PRIMARY KEY (role_id);
 :   ALTER TABLE ONLY public.roles DROP CONSTRAINT roles_pkey;
       public                 postgres    false    217            �           2606    18067    users users_email_key 
   CONSTRAINT     Q   ALTER TABLE ONLY public.users
    ADD CONSTRAINT users_email_key UNIQUE (email);
 ?   ALTER TABLE ONLY public.users DROP CONSTRAINT users_email_key;
       public                 postgres    false    218            �           2606    18065    users users_pkey 
   CONSTRAINT     S   ALTER TABLE ONLY public.users
    ADD CONSTRAINT users_pkey PRIMARY KEY (user_id);
 :   ALTER TABLE ONLY public.users DROP CONSTRAINT users_pkey;
       public                 postgres    false    218            �           1259    18128    idx_banner_ads_is_active    INDEX     T   CREATE INDEX idx_banner_ads_is_active ON public.banner_ads USING btree (is_active);
 ,   DROP INDEX public.idx_banner_ads_is_active;
       public                 postgres    false    221            �           1259    18130 "   idx_carousel_banners_display_order    INDEX     h   CREATE INDEX idx_carousel_banners_display_order ON public.carousel_banners USING btree (display_order);
 6   DROP INDEX public.idx_carousel_banners_display_order;
       public                 postgres    false    222            �           1259    18129    idx_carousel_banners_is_active    INDEX     `   CREATE INDEX idx_carousel_banners_is_active ON public.carousel_banners USING btree (is_active);
 2   DROP INDEX public.idx_carousel_banners_is_active;
       public                 postgres    false    222            �           1259    18126    idx_posts_author_id    INDEX     J   CREATE INDEX idx_posts_author_id ON public.posts USING btree (author_id);
 '   DROP INDEX public.idx_posts_author_id;
       public                 postgres    false    220            �           1259    18125    idx_posts_category_id    INDEX     N   CREATE INDEX idx_posts_category_id ON public.posts USING btree (category_id);
 )   DROP INDEX public.idx_posts_category_id;
       public                 postgres    false    220            �           1259    18127    idx_posts_is_published    INDEX     P   CREATE INDEX idx_posts_is_published ON public.posts USING btree (is_published);
 *   DROP INDEX public.idx_posts_is_published;
       public                 postgres    false    220            �           1259    18124    idx_users_role_id    INDEX     F   CREATE INDEX idx_users_role_id ON public.users USING btree (role_id);
 %   DROP INDEX public.idx_users_role_id;
       public                 postgres    false    218            �           2606    18098    posts fk_author    FK CONSTRAINT     �   ALTER TABLE ONLY public.posts
    ADD CONSTRAINT fk_author FOREIGN KEY (author_id) REFERENCES public.users(user_id) ON DELETE RESTRICT;
 9   ALTER TABLE ONLY public.posts DROP CONSTRAINT fk_author;
       public               postgres    false    3534    220    218            �           2606    18093    posts fk_category    FK CONSTRAINT     �   ALTER TABLE ONLY public.posts
    ADD CONSTRAINT fk_category FOREIGN KEY (category_id) REFERENCES public.categories(category_id) ON DELETE RESTRICT;
 ;   ALTER TABLE ONLY public.posts DROP CONSTRAINT fk_category;
       public               postgres    false    219    220    3536            �           2606    18068    users fk_role    FK CONSTRAINT     �   ALTER TABLE ONLY public.users
    ADD CONSTRAINT fk_role FOREIGN KEY (role_id) REFERENCES public.roles(role_id) ON DELETE RESTRICT;
 7   ALTER TABLE ONLY public.users DROP CONSTRAINT fk_role;
       public               postgres    false    3529    217    218            u   �   x�]��N�0D��+�#Ǜ�I�4��N�����%��#{C���i���۾>�Fr�:�ZǍ���<���]w_<!�y9�ǈ���W�L�}{`�xe�	����Gf6bG��~�����b"Z� ľ�G�<�Vm1���T��.��۰.$��=&�@�(�O����M�����f.���z�A2��� �<�rP��`���O\��?qS���ھ�t��g�kU����^      v     x����n�0��٧�cu�d�f��RW���*$�jO6f;���˩�����l���K�x���?R]�$X݊���LJ&D��Be�Tp9ye�{�?�x��:CBOp�N�-����;�{k��X�'��o�>��o�l��4��(%9��v�摵�2!�FmQ��:X����x��+��/x��,/��Ap�~��u@��B�G�����UK����d��'��Q�>�s�P�^�dڞ�	8��J�U�-j��W!��x� �:M�S:�[���9;DAJ�E�p;h���T����iR�J*!)xQ1^�|�o��6/S~QV�x��+Yp"޵�B�a�5k��axQ�����J$�=���$�p�|����g�S�w�����^J7��z���{�ہR���t���(6�r�9�c�Q5�X,�Ы�d��=��51y���8}��,����?�S�� �j�0n����j�=������u�?D���.���zlT�qg�zy@;N=?�!�$-��૷�u���Z/�������QD+      s     x�m��n� E��W����l�R?��nx�i�L2"Yt��d��Zɒ�Ͻ�:R��V G��ǐ�cɱD+�0؝*�}Z�,�v:���J]/�rc�v��mǾ���9\�3�L[��u�օ���l����h.�K������@;� TG�`��Eh�Q���h32��R�;��M����Jyt�v��<ȢdM��H�,�µ�IA4)�ܝ浹]���s������� ������]ŚD�vLc>Ru<��E1�K�D�0u����o<��3�������8|�      t   _  x��X�r�6]�_�l&vE��IvU��J,�c)�d&S.���H��nS�|�l�j���%s.В�8[/�H<..�9�\�Y��m�m�A�)��,�4Ȫ&��h��9��7\�{�+i��e�w�a�{)[���;Ws�_��լ1X�''��^�(����a�R�e�ңwL�9
<�
�#,3�l�9e^�Q`���-��ԁM� t;����OY�F#��e��v�T����=�V�X�j��Ê�Z0��Z���a�_��F˵��FQ�����` �>�SY7㔍l[�4ւɑ��j��ʽ��)b�&:�B�SX�IpLP�;��������ߗ�̼GG�?g49�(�Р�N����=� of+��{��U���!�Zs���[�4�-�^%!�֤�=H���4ȣ�5�74����9;�e��W���=��/��t.��б��E��H��ؿ��[�yr�Y;��zm�Uk�f\�®�O�u��p���8['��ݳwQ�y��ɻh��e~��O�o.z6��^�˟�yr=��]��'ŦqSfA^�M��MTmiZp��MSU�I\��y �e�F�&(�v�U��e^����a�aD��m�l�bEy�)�
��oc'�4߆�*��$��}�$q��l��Y��e�8Rl�M�&m���ɵ�X��.�'�aV��J���^?���v<�Xi����e�g��	`Љ�.-^���Q�'B1n�|���&t �@>
��i� Á�� Wp��ƺ�.�8���Hb#��gn~���F���7�1��C�0�������n/'0C�v�c5)�����������AK�Jsp�*<�h�+E��h��;>�[��BѨo{��K^7l�$8	!q�M�9�����٪@4~˽l�r�x#������#߉��ٸ �{���R�-&w��j�͖])�� �`����_�tz܈���G��A��^�V��eU�amh߰�����0k��C5��f��:L��&��N-��ֈE� 5�9�Mw$b�A5'Y�$D10���������Q�j�S���\��Y�l�r�$�M�gi����r��eT$�tQ�Q�&AQ��Q��GY�8-c��M]%'$�oPL�����%�~����%5����~i�ľ#�]�BLON.Z�H���U�A�R��l��κ�ͅ����yb�CǱ�hN?.1byޣ0~R�F�o�x���f��F�i($������'���"����ܟ	w1>����ԝhP;���w���P��R3�$�:ҡX�Z(� lK/��#�^Ȧ��7�[}_n���.�w�.�H�f���^�����,�����X��7���u�Ơ��$+>���h�~�;G@$�*r �=�q(�����yg�Zb�ݘψ�P���pE٧��m���"���c8��"�y�Q\iU�A7<�7�؄Y�Dyt����K�/�n\�sa�P�ޢ�\����)�o �k"��uG�vv'�o��'o;����d}�[��HA�!l�����ת� �U"���s-,'7D��h�ԍB����4���0��`^!`�Q�O�K�}&�"��Dd�T�}'B�����͕�Kg�+yZ�d��f�ꇒ�Q��@�p��S��9��.x��N�2���T�4ئ�Uk�._���������ST�{<�� �PZ�c��Vb��(��� ��5P�C�U#��\;���s���F�6LVIY&e��ͷ	���ސ�Xlڠ��(H�q�u��ʚ�giĽ�B������]���9�P�1��Ⱦ{�s)���?O��١I�U��Ka;���)g������k�ǁ�8!��(���n�|�g�9dm�R�{e�.(HE߬�C���F`���"�����	`���Gx���|i:1����"�	$�5���[���s_���5��}?+޲W�҇��FK��o^?��!�c�4A�hj�%[�i��<3v {�I��&D�mע�����nQ+�V��o ��>H�Y���=t/�� 
��/�sV�7�y \�P�Ϻ2�r}I���i�c
��{��)��7r����_�r}��ח���weP�2�򹷟K��[*	WE�a�N��[��.��98!GiY�զ��,y�mN���9��o	y[���=�͸g�I�Ӡǅ;~���&X���}�̍C,i4�=��"��YoFq�;�V:�@�g�4hj&O�̤����V�Ly���9yR�cxp��F�a��fН况���}��C�ໆ�8��Ɨ��J��p��APE,���k%؅AEj~�j���2��7�ݯ���C���j�s�j>��Ve ?�j���˂k����1#2��t��CQ��zn�#]G���-�<E�4�����9dڠ<\R�K�
r�8� *Ɇ��;K4���A:VƳ�8�*X�AQ4p�Frx�7�=gg(�T�p�:e7�:����dF���2�~ &���Ab���}§����'�M΋>~���Jh��q]���shw��?�Y{/�{	/�RJ�q*��m���D��8>nb��9��L�{E�B9�F9fg{��;�C'I���Z�ܺ N���;n��o�v+Z�;C?<�N{dЊ=#���w����I�;�����#xNћJ���0����v7Ԕ�.�W�3I_Rg@���P�Z��U�C���⾏h��O|P@�C�:"��|$�����J���B%�֎�GM�ą�'<2���7�P�iY�qL�]eq��|
aO��]�L�s�t�"�� �6|M�cQ�����_��ţf<��wj����9L���)86��y���Y��ځs��� no���{��?����m���"�s���I�͊U�GI�B���ѣG�ڬi+      q   �   x�m̽N�@�:y��'G������hi�'�+���?�t�����4a�;XY���eM�,�=�k��}����骶J�3�9]0��'a�P�@<g����ݤQ������+Mt2+�L���)������"�`[��)2/����[���g7˒NMX)d#�
ҭ�E h��b�G������Ji%�1�z��q���F�      r   �   x�}�=k�0��Y��Ù�t>�����P�d�"Y1��66�׷P�v}��5�B��(@�H[\�ԉ�āԶ�9��)��!��W�?Xw�4_�P�^m}�~n�{zҏo���nW��R��u?:�����ew�|߇�ؤt�Ӥ�GL��T�bb�̍��P)ʠi 	P�W�V�5���K���굮��(#B�     