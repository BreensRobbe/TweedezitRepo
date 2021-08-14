import os
import json
import time
import random
import asyncio
from azure.iot.device import IoTHubDeviceClient

def main():
    device_client = IoTHubDeviceClient.create_from_connection_string("HostName=Iothublabo.azure-devices.net;DeviceId=pcbreens;SharedAccessKey=iGgRZSMQqtrHL1UeY+Xg1K6y+YBDJMgVxmL5Ev5Mj9k=")

    device_client.connect()

    device_client.send_message("Hello, ik ben Breens")

    device_client.disconnect()

if __name__ == "__main__":
    main()
