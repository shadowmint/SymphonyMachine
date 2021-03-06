using UnityEngine;
using Jam.Symbols;
using Jam.Weathers;
using Weather;

namespace Jam.Actions
{
    public class PickWeatherForPhrase : ITask
    {
        public SymbolPhrase phrase;

        public WeatherDelta selected;

        public bool debug;

        public PickWeatherForPhrase(SymbolPhrase phrase, bool debug)
        {
            this.phrase = phrase;
            this.debug = debug;
        }

        public void Execute(TaskComplete callback)
        {
            // Find all the matches we can to various weathers
            var match = WeatherUtils.OrderedMatches(phrase);

            // Debugging why we picked X
            if (debug)
            {
                Debug.Log("");
                Debug.Log("------ WEATHER CHOICE DEBUG ------");
                Debug.Log("found " + match.Count + " possible weather matches...");
                foreach (var m in match) { m.Debug(); }
            }

            // Select best match~
            selected = match.Count > 0 ? match[0] : null;
            var selectedId = match.Count > 0 ? match[0].weather.weather : WeatherId.FINE;

            // Update symbol phrase
            phrase.weather = selectedId;
            phrase.weatherPrefab = WeatherUtils.WeatherPrefab(phrase.weather);

            if (debug)
            {
                Debug.Log(string.Format("Pick weather for phrase: {0}", selected));
                Debug.Log("");
            }

            // Done~
            if (callback != null)
            { callback(this); }
        }
    }
}
