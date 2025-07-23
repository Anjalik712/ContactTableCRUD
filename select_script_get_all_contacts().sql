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
        "Values": ["xy"]
      }
	]
  }'::jsonb,
  '{}'::jsonb,
  0,
  0
);
