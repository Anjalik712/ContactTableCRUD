SELECT * FROM get_all_contacts(
  '{
    "FirstName": [
      {
        "Values": [""]
      }
	],
	"SecondName":[
		{
			"Values":[""]
		}
    ],"LastName": [
      {
        "Values": [""]
      }
	]
  }'::jsonb,
  '[
	{
		"SortBy": "FirstName",
		"SortDirection": "DESC" 
	}
   ]'::jsonb,
  0,
  0
);
