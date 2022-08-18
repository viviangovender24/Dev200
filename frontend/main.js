var elem;
var curDate = '2016-05-18';
var curTime = 11;

function checkSlotAvailability(time, jobLength, date, availability) 
{
    var prefix = date;
    elem = document.getElementById(prefix + i);

    setButtonState(elem, "Available"); // sets button to Available

    if(curDate===date && time <= curTime + 1) // checks date and 1 hour lead time
    {
      setButtonState(elem, "Unavailable");
      return;
    }

    if (availability.includes(time) == false) // no time equals full immediately
    {
            setButtonState(elem, "Full");
    }
	else if(time+jobLength > 18) // length more than workday, set to unavailable
    {
            setButtonState(elem, "Unavailable");
    }
    else if(time == 17 && availability.includes(time-1)) // 1 hour cut off time
    {
            setButtonState(elem, "Available");
    }
	else if(time == 9) // Start time case for 1st slot
    {
        for(x = 0; x < jobLength; x++)
        {
            if(availability.includes(time+x) == false) // enforces all slot not full
            {
                setButtonState(elem, "Unavailable");
                break;
            }
            setButtonState(elem, "Available");
        }
    }
	else // all other
    {
        for(x = 0; x < jobLength; x++)
        {
            if(availability.includes(time+x) == false || availability.includes(time-1) == false) // 1 hr buffer
            {
                setButtonState(elem, "Unavailable");
                break;
            }
            setButtonState(elem, "Available");
        }
    }
}


function selectSlot(n, val)
{
    updateSlider(job_length) // change if change slider position

    var els = document.getElementsByName(n); // next time slots
    var num = parseInt(val)

   for (i = num; i < num + job_length; i++)
   {
      elem = document.getElementById(els[i].id);
      setButtonState(elem, "Selected");
   }
}


function setButtonState(id, state)
{
  if(state == "Full")
  {
    id.disabled = true;
    id.innerText = "Full";
    id.style.background = "	#EE4B2B";
  }
  if(state == "Unavailable")
  {
    id.disabled = true;
    id.innerText = "Unavailable";
    id.style.background = "#8c8c8c";
  }
  if(state == "Selected")
  {
    elem.innerText = "Selected";
    elem.style.background = "green";
  }
  if(state == "Available")
  {
    elem.disabled = false;
    elem.innerText = "Available";
    elem.style.background = "#FFFFFF";
  }
}

const data = [
  {
    "Date": "2016-05-18",
    "HoursAvailable": [9, 10, 11, 12, 13, 14, 17]
  },
  {
    "Date": "2016-05-19",
    "HoursAvailable": [9, 10, 11, 12, 13, 14, 15, 16, 17]
  },
  {
    "Date": "2016-05-20",
    "HoursAvailable": [9, 10, 14, 15, 16, 17]
  },
  {
    "Date": "2016-05-21",
    "HoursAvailable": [9, 10, 11, 12, 13]
  },
  {
    "Date": "2016-05-23",
    "HoursAvailable": [13, 14, 15, 16]
  },
  {
    "Date": "2016-05-24",
    "HoursAvailable": [11, 12, 15, 16, 17]
  }
];

var parsed = JSON.parse(JSON.stringify(data));
var slider = document.getElementById("slider");
var job_length = 1; //controlled by slider
var dispDiv = document.getElementById("dispDiv");
dispDiv.innerHTML = "The job length is = " + job_length + " hour/s";

window.onload = updateSlider(job_length);

//value change slider
function updateSlider(slideAmount)
{
    job_length = parseInt(slideAmount);
    dispDiv.innerHTML = "The job length is = " + job_length + " hour/s";

    for(obj in parsed)
    {
      for(i = 9; i < 18; i++)
      {
          checkSlotAvailability(i, job_length, parsed[obj].Date, parsed[obj].HoursAvailable);
      }
    }
}

//checkSlotAvailability(9, 1, '2016-05-20', [9, 10, 14, 15, 16, 17]);
// => AVAILABLE
//checkSlotAvailability(10, 1, '2016-05-20', [9, 10, 14, 15, 16, 17]);
// => UNAVAILABLE
//checkSlotAvailability(11, 1, '2016-05-20', [9, 10, 14, 15, 16, 17]);
// => FULL