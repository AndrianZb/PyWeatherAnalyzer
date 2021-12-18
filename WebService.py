from flask import Flask
from DAL.DBWeather import DBWeather
from flask import request, jsonify
from datetime import datetime
from WebScraper import WeatherScraper
import time


app = Flask(__name__)
app.config["DEBUG"] = True



#system = DBWeather()
#scraper = WeatherScraper()

@app.route("/", methods=['GET'])
def select_all_temp():
    system = DBWeather()
    temps = list(system.select_all_temp())
    return jsonify(temps)


@app.route("/<int:temp_date>", methods=['GET'])
def select_temp(temp_date):
    system = DBWeather()
    temp = system.select_all_temp(temp_date)
    return jsonify(temp)


@app.route("/delete", methods=['DELETE'])
def delete_all_temp():
    system = DBWeather()
    temp = system.delete_all_temp()
    return jsonify(temp)


@app.route("/", methods=['POST'])
def post_temp():
    system = DBWeather()

    #weatherCom= scraper.get_current_temp_from_weathercom()
    #meteoMedia= scraper.get_current_temp_from_meteomedia()

    # Receive data
    #data = request.json()
    temp = request.json.get('temp')
    weatherCom = request.json.get('tempWeatherCom')
    meteoMedia = request.json.get('tempMeteoMedia')

    # Get Day, Month, Time
    current_date = datetime.now()
    t = time.localtime()
    current_time = time.strftime("%H:%M", t)

    system.post_temp(weatherCom, meteoMedia, temp, current_date.day, current_date.month, current_time)
    return "Posted Successfully"
