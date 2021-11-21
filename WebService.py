import flask
from DAL.DBWeather import DBWeather
from flask import request, jsonify
from datetime import datetime
import time

app = flask.Flask(__name__)
app.config["DEBUG"] = True


system = DBWeather()


@app.route("/pythonanywhere", methods=['GET'])
def select_all_temp():
    temps = list(system.select_all_temp())
    return jsonify(temps)


@app.route("/pythonanywhere/<int:temp_date>", methods=['GET'])
def select_temp(temp_date):
    temp = system.select_all_temp(temp_date)
    return jsonify(temp)


@app.route("/pythonanywhere", methods=['DELETE'])
def delete_all_temp():
    temp = system.delete_all_temp()
    return jsonify(temp)


@app.route("/pythonanywhere/new", methods=['POST'])
def post_temp():
    # Receive data
    data = request.json()
    temp = data.get('temp')

    # Get data from webscraping
 externalService.getExternalTemp()

    # Get Day, Month, Time
    current_date = datetime.now()
    t = time.localtime()
    current_time = time.strftime("%H:%M", t)

    system.post_temp(12, 12, temp, current_date.day, current_date.month, current_time)
    return 200


app.run()
