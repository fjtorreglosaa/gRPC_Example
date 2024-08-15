from service_pb2_grpc import CompanyServicer, add_CompanyServicer_to_server
from service_pb2 import JobApplication
import grpc
from concurrent import futures

class CompanyService(CompanyServicer):
    
    def Ready(self, request, context):
        return request;
    
    def SendApplication(self, request, context):
        
        print(f"Application received from {request.name}... job {len(request.jobs)}")
        
        return JobApplication(application_date = 140820241025) # 14/08/2024 10:25

def start():
    server = grpc.server(futures.ThreadPoolExecutor(max_workers=5))
    add_CompanyServicer_to_server(CompanyService(), server)
    server.add_insecure_port('[::]:50000')
    print("Server running on port 50000...")
    server.start()
    server.wait_for_termination()
    pass

if __name__ == "__main__":
    start();