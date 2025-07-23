-- FUNCTION: public.get_all_contacts(jsonb, jsonb, integer, integer)

-- DROP FUNCTION IF EXISTS public.get_all_contacts(jsonb, jsonb, integer, integer);

CREATE OR REPLACE FUNCTION public.get_all_contacts(
	filters jsonb,
	orderby jsonb,
	take integer,
	skip integer)
    RETURNS TABLE(id integer, firstname character varying, middlename character varying, lastname character varying, age integer, dob date, createdby character varying, createddate timestamp without time zone, modifiedby character varying, modifieddate timestamp without time zone) 
    LANGUAGE 'plpgsql'
    COST 100
    VOLATILE PARALLEL UNSAFE
    ROWS 1000

AS $BODY$
DECLARE
	base_query TEXT;
	final_query TEXT;
	name_filter TEXT := '';
    take_skip_query TEXT := '';  
	firstname_pattern TEXT := '';
	middlename_pattern TEXT := '';
	lastname_pattern TEXT := '';
BEGIN
	IF filters ? 'FirstName' THEN
		firstname_pattern :=lower('%'||(filters->'FirstName'->0->'Values'->>0)||'%');
		name_filter := name_filter || format(
			$$ AND LOWER("FirstName") ILIKE %L $$,
			firstname_pattern
		);
	END IF;	
	IF filters ? 'MiddleName' THEN
		middlename_pattern :=lower('%'||(filters->'MiddleName'->0->'Values'->>0)||'%');
		name_filter := name_filter || format(
			$$ AND LOWER("MiddleName") ILIKE %L $$,
			middlename_pattern
		);
	END IF;	
	IF filters ? 'LastName' THEN
		lastname_pattern :=lower('%'||(filters->'LastName'->0->'Values'->>0)||'%');
		name_filter := name_filter || format(
			$$ AND LOWER("LastName") ILIKE %L $$,
			lastname_pattern
		);
	END IF;	
	
	IF take > 0 THEN
		    take_skip_query := format('LIMIT %s', take);
		END IF;
		
		IF skip > 0 THEN
		    take_skip_query := format('%s OFFSET %s', 
		        COALESCE(take_skip_query, ''),  
		        skip
		    );
	END IF;
	
	base_query='SELECT 
        "Id"::INT,
        "FirstName"::VARCHAR,
        "MiddleName"::VARCHAR,
        "LastName"::VARCHAR,
        "Age"::INT,
        "DOB"::DATE,
        "CreatedBy"::VARCHAR,
        "CreatedDate"::TIMESTAMP,
        "ModifiedBy"::VARCHAR,
        "ModifiedDate"::TIMESTAMP
    FROM "Contact" WHERE true';
	final_query := base_query || name_filter || ' ' || take_skip_query;
    RETURN QUERY EXECUTE final_query;
    
END;
$BODY$;

ALTER FUNCTION public.get_all_contacts(jsonb, jsonb, integer, integer)
    OWNER TO postgres;
