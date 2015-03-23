/*******************************************************************************
 (c) 2005-2014 Copyright, Real-Time Innovations, Inc.  All rights reserved.
 RTI grants Licensee a license to use, modify, compile, and create derivative
 works of the Software.  Licensee has the right to distribute object form only
 for use with RTI products.  The Software is provided "as is", with no warranty
 of any type, including any warranty for fitness for any purpose. RTI is under
 no obligation to maintain or support the Software.  RTI shall not be liable for
 any incidental or consequential damages arising out of the use or inability to
 use the software.
 ******************************************************************************/
/*   
ordered_group_publisher.cs

A publication of data of type ordered_group

This file is derived from code automatically generated by the rtiddsgen 
command:

rtiddsgen -language C# -example <arch> ordered_group.idl

Example publication of type ordered_group automatically generated by 
'rtiddsgen'. To test them follow these steps:

(1) Compile this file and the example subscription.

(2) Start the subscription with the command
objs\<arch>${constructMap.nativeFQNameInModule}_subscriber <domain_id> <sample_count>

(3) Start the publication with the command
objs\<arch>${constructMap.nativeFQNameInModule}_publisher <domain_id> <sample_count>

(4) [Optional] Specify the list of discovery initial peers and 
multicast receive addresses via an environment variable or a file 
(in the current working directory) called NDDS_DISCOVERY_PEERS. 

You can run any number of publishers and subscribers programs, and can 
add and remove them dynamically from the domain.

Example:

To run the example application on domain <domain_id>:

bin\<Debug|Release>\ordered_group_publisher <domain_id> <sample_count>
bin\<Debug|Release>\ordered_group_subscriber <domain_id> <sample_count>
*/

using System;
using System.Collections.Generic;
using System.Text;

public class ordered_groupPublisher {

    public static void Main(string[] args) {

        // --- Get domain ID --- //
        int domain_id = 0;
        if (args.Length >= 1) {
            domain_id = Int32.Parse(args[0]);
        }

        // --- Get max loop count; 0 means infinite loop  --- //
        int sample_count = 0;
        if (args.Length >= 2) {
            sample_count = Int32.Parse(args[1]);
        }

        /* Uncomment this to turn on additional logging
        NDDS.ConfigLogger.get_instance().set_verbosity_by_category(
            NDDS.LogCategory.NDDS_CONFIG_LOG_CATEGORY_API, 
            NDDS.LogVerbosity.NDDS_CONFIG_LOG_VERBOSITY_STATUS_ALL);
        */

        // --- Run --- //
        try {
            ordered_groupPublisher.publish(
                domain_id, sample_count);
        }
        catch(DDS.Exception)
        {
            Console.WriteLine("error in publisher");
        }
    }

    static void publish(int domain_id, int sample_count) {

        // --- Create participant --- //

        /* To customize participant QoS, use 
        the configuration file USER_QOS_PROFILES.xml */
        DDS.DomainParticipant participant =
        DDS.DomainParticipantFactory.get_instance().create_participant(
            domain_id,
            DDS.DomainParticipantFactory.PARTICIPANT_QOS_DEFAULT, 
            null /* listener */,
            DDS.StatusMask.STATUS_MASK_NONE);
        if (participant == null) {
            shutdown(participant);
            throw new ApplicationException("create_participant error");
        }

        // --- Create publisher --- //

        /* To customize publisher QoS, use 
        the configuration file USER_QOS_PROFILES.xml */
        DDS.Publisher publisher = participant.create_publisher(
            DDS.DomainParticipant.PUBLISHER_QOS_DEFAULT,
            null /* listener */,
            DDS.StatusMask.STATUS_MASK_NONE);
        if (publisher == null) {
            shutdown(participant);
            throw new ApplicationException("create_publisher error");
        }

        // --- Create topic --- //

        /* Register type before creating topic */
        System.String type_name = ordered_groupTypeSupport.get_type_name();
        try {
            ordered_groupTypeSupport.register_type(
                participant, type_name);
        }
        catch(DDS.Exception e) {
            Console.WriteLine("register_type error {0}", e);
            shutdown(participant);
            throw e;
        }

        /* Start changes for Ordered Presentation Group example */
        /* TOPICS */ 
        /* To customize topic QoS, use 
        the configuration file USER_QOS_PROFILES.xml */
        DDS.Topic topic1 = participant.create_topic(
            "Topic1",
            type_name,
            DDS.DomainParticipant.TOPIC_QOS_DEFAULT,
            null /* listener */,
            DDS.StatusMask.STATUS_MASK_NONE);
        if (topic1 == null) {
            shutdown(participant);
            throw new ApplicationException("create_topic error");
        }

        /* To customize topic QoS, use 
                the configuration file USER_QOS_PROFILES.xml */
        DDS.Topic topic2 = participant.create_topic(
            "Topic2",
            type_name,
            DDS.DomainParticipant.TOPIC_QOS_DEFAULT,
            null /* listener */,
            DDS.StatusMask.STATUS_MASK_NONE);
        if (topic2 == null) {
            shutdown(participant);
            throw new ApplicationException("create_topic error");
        }

        /* To customize topic QoS, use 
        the configuration file USER_QOS_PROFILES.xml */
        DDS.Topic topic3 = participant.create_topic(
            "Topic3",
            type_name,
            DDS.DomainParticipant.TOPIC_QOS_DEFAULT,
            null /* listener */,
            DDS.StatusMask.STATUS_MASK_NONE);
        if (topic3 == null) {
            shutdown(participant);
            throw new ApplicationException("create_topic error");
        }

        /* DATAWRITERS */

        /* To customize data writer QoS, use 
        the configuration file USER_QOS_PROFILES.xml */
        DDS.DataWriter writer1 = publisher.create_datawriter(
            topic1,
            DDS.Publisher.DATAWRITER_QOS_DEFAULT,
            null /* listener */,
            DDS.StatusMask.STATUS_MASK_NONE);
        if (writer1 == null) {
            shutdown(participant);
            throw new ApplicationException("create_datawriter error");
        }
        ordered_groupDataWriter ordered_group_writer1 =
        (ordered_groupDataWriter)writer1;


        DDS.DataWriter writer2 = publisher.create_datawriter(
            topic2,
            DDS.Publisher.DATAWRITER_QOS_DEFAULT,
            null /* listener */,
            DDS.StatusMask.STATUS_MASK_NONE);
        if (writer2 == null) {
            shutdown(participant);
            throw new ApplicationException("create_datawriter error");
        }
        ordered_groupDataWriter ordered_group_writer2 =
        (ordered_groupDataWriter)writer2;

        DDS.DataWriter writer3 = publisher.create_datawriter(
            topic3,
            DDS.Publisher.DATAWRITER_QOS_DEFAULT,
            null /* listener */,
            DDS.StatusMask.STATUS_MASK_NONE);
        if (writer3 == null) {
            shutdown(participant);
            throw new ApplicationException("create_datawriter error");
        }
        ordered_groupDataWriter ordered_group_writer3 =
        (ordered_groupDataWriter)writer3;

        // --- Write --- //

        /* Instances */

        ordered_group instance1 = ordered_groupTypeSupport.create_data();
        if (instance1 == null) {
            shutdown(participant);
            throw new ApplicationException(
                "ordered_groupTypeSupport.create_data error");
        }

        ordered_group instance2 = ordered_groupTypeSupport.create_data();
        if (instance2 == null) {
            shutdown(participant);
            throw new ApplicationException(
                "ordered_groupTypeSupport.create_data error");
        }
        ordered_group instance3 = ordered_groupTypeSupport.create_data();
        if (instance3 == null) {
            shutdown(participant);
            throw new ApplicationException(
                "ordered_groupTypeSupport.create_data error");
        }

        /* End changes for Ordered Presentation Example */

        /* For a data type that has a key, if the same instance is going to be
        written multiple times, initialize the key here
        and register the keyed instance prior to writing */
        DDS.InstanceHandle_t instance_handle = DDS.InstanceHandle_t.HANDLE_NIL;
        /*
        instance_handle = ordered_group_writer.register_instance(instance);
        */

        /* Main loop */
        const System.Int32 send_period = 1000; // milliseconds
        for (int count=0;
        (sample_count == 0) || (count < sample_count);
        ++count) {
            Console.WriteLine("Writing ordered_group, count {0}", count);
            
            /* Start changes for Ordered Presentation Example */
            /* Modify the data to be sent here */
            /* Instance 1 */
            instance1.message = "First sample, Topic 1 by DataWriter number 1";
            try {
                ordered_group_writer1.write(instance1, ref instance_handle);
            }
            catch(DDS.Exception e) {
                Console.WriteLine("write error {0}", e);
            }

            instance1.message = "Second sample, Topic 1 by DataWriter number 1";
            try {
                ordered_group_writer1.write(instance1, ref instance_handle);
            }
            catch (DDS.Exception e) {
                Console.WriteLine("write error {0}", e);
            }

            /* Instance 2 */
            instance2.message = "First sample, Topic 2 by DataWriter number 2";
            try {
                ordered_group_writer2.write(instance2, ref instance_handle);
            }
            catch (DDS.Exception e) {
                Console.WriteLine("write error {0}", e);
            }

            instance2.message = "Second sample, Topic 2 by DataWriter number 2";
            try {
                ordered_group_writer2.write(instance2, ref instance_handle);
            }
            catch (DDS.Exception e) {
                Console.WriteLine("write error {0}", e);
            }

            /* Instance 3 */
            instance3.message = "First sample, Topic 3 by DataWriter number 3";
            try {
                ordered_group_writer3.write(instance3, ref instance_handle);
            }
            catch (DDS.Exception e) {
                Console.WriteLine("write error {0}", e);
            }

            instance3.message = "Second sample, Topic 3 by DataWriter number 3";
            try {
                ordered_group_writer3.write(instance3, ref instance_handle);
            }
            catch (DDS.Exception e) {
                Console.WriteLine("write error {0}", e);
            }

            System.Threading.Thread.Sleep(send_period);
        }

        /*
        try {
            ordered_group_writer.unregister_instance(
                instance, ref instance_handle);
        } catch(DDS.Exception e) {
            Console.WriteLine("unregister instance error: {0}", e);
        }
        */

        // --- Shutdown --- //

        /* Delete data sample */
        try {
            ordered_groupTypeSupport.delete_data(instance1);
            ordered_groupTypeSupport.delete_data(instance2);
            ordered_groupTypeSupport.delete_data(instance3);
        } catch(DDS.Exception e) {
            Console.WriteLine(
                "ordered_groupTypeSupport.delete_data error: {0}", e);
        }

        /* Delete all entities */
        shutdown(participant);
    }

    static void shutdown(
        DDS.DomainParticipant participant) {

        /* Delete all entities */

        if (participant != null) {
            participant.delete_contained_entities();
            DDS.DomainParticipantFactory.get_instance().delete_participant(
                ref participant);
        }

        /* RTI Connext provides finalize_instance() method on
        domain participant factory for people who want to release memory
        used by the participant factory. Uncomment the following block of
        code for clean destruction of the singleton. */
        /*
        try {
            DDS.DomainParticipantFactory.finalize_instance();
        } catch (DDS.Exception e) {
            Console.WriteLine("finalize_instance error: {0}", e);
            throw e;
        }
        */
    }
}

