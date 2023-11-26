using AutoMapper;
using SalesOrderReceiverService.Application.DTOs;
using SalesOrderReceiverService.Application.Interfaces;
using SalesOrderReceiverService.Domain.Entities;
using SalesOrderReceiverService.Domain.Interfaces;

namespace SalesOrderReceiverService.Application.Services
{
    public class SalesOrderReceiverRabbitMQService : ISalesOrderReceiverRabbitMQService
    {
        private ISalesOrderReceiverRabbitMQRepository _salesOrderReceiverRabbitMQRepository;
        private readonly IMapper _mapper;

        public SalesOrderReceiverRabbitMQService(ISalesOrderReceiverRabbitMQRepository salesOrderReceiverRabbitMQRepository, 
                                               IMapper mapper)
        {
            _salesOrderReceiverRabbitMQRepository = salesOrderReceiverRabbitMQRepository;
            _mapper = mapper;
        }

        public async Task<List<MessageDTO>> Receive()
        {
            List<Message> messages = await _salesOrderReceiverRabbitMQRepository.Receive();            

            List<MessageDTO> messagesDTO = new List<MessageDTO>();
            MessageDTO messageDTO;

            foreach (Message message in messages)
            {
                messageDTO = new MessageDTO();
                messageDTO.SalesOrderDto = _mapper.Map<SalesOrderDTO>(message.SalesOrder);
                messageDTO.SalesOrderItemsDto = _mapper.Map<List<SalesOrderItemDTO>>(message.SalesOrderItems);

                messagesDTO.Add(messageDTO);
            }

            return messagesDTO;
        }
    }
}