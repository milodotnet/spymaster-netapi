# Spymaster Api

## TODO

1. Api Response + Contract

        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            var agent = _agentService.Get(id);

            return new ObjectResult(agent)
            {
                StatusCode = (int)HttpStatusCode.OK
            };
        }


 2. Provider State

https://gist.github.com/milodotnet/4cfc5ff43ce059ad184361c448b5f0df 

 3. Fix the IS8601 issue

https://gist.github.com/milodotnet/c40354d7c9f53362ed4a410005fd6a94       